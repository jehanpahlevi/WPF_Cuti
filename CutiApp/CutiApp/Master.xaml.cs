using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CutiApp.MyModel;

namespace CutiApp
{
    /// <summary>
    /// Interaction logic for Master.xaml
    /// </summary>
    public partial class Master : Window
    {
        MyContext context = new MyContext();
        Employee employee = new Employee();
        Department department = new Department(); 

        public Master()
        {
            InitializeComponent();
            TampilDataKaryawan();
        }

        #region Karyawan

        public Employee GetByIdKaryawan(int id)
        {
            return context.Employees.Find(id);
        }

        private void btnSimpan_Click(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt16(cbDepartment.SelectedValue);
            var depid = context.Departments.Find(Id);
            employee.Name = txtNama.Text;
            employee.Departments = depid;
            employee.Email = txtEmail.Text;
            employee.Telp = txtNoTelp.Text;
            employee.CreateDate = DateTimeOffset.Now;
            employee.JobTitle = txtJobTitle.Text;
            employee.Status = txtStatus.Text;
            employee.TotalChilds = Convert.ToInt16(txtJumlahAnak.Text);
            employee.Password = txtPassword.Text;
            employee.ThisYearBalance = 12;
            employee.LastYearBalance = 0;
            context.Employees.Add(employee);
            context.SaveChanges();

            MessageBox.Show("Data berhasil disimpan!");
            TampilDataKaryawan();
        }

        public void TampilDataKaryawan()
        {
            var getData = context.Employees.Where(x => x.IsDelete == false).ToList();
            dgvKaryawan.ItemsSource = getData;
        }


        private void dgvKaryawan_SelectionCellsChanged(object sender, SelectionChangedEventArgs e)
        {
            object tampil = dgvKaryawan.SelectedItem;
            if (tampil != null)
            {
                txtIdKaryawan.Text = (dgvKaryawan.SelectedCells[0].Column.GetCellContent(tampil) as TextBlock).Text;
                txtNama.Text = (dgvKaryawan.SelectedCells[1].Column.GetCellContent(tampil) as TextBlock).Text;
                cbDepartment.Text = (dgvKaryawan.SelectedCells[2].Column.GetCellContent(tampil) as TextBlock).Text;
                txtEmail.Text = (dgvKaryawan.SelectedCells[3].Column.GetCellContent(tampil) as TextBlock).Text;
                txtNoTelp.Text = (dgvKaryawan.SelectedCells[4].Column.GetCellContent(tampil) as TextBlock).Text;
                txtJobTitle.Text = (dgvKaryawan.SelectedCells[5].Column.GetCellContent(tampil) as TextBlock).Text;
                txtStatus.Text = (dgvKaryawan.SelectedCells[6].Column.GetCellContent(tampil) as TextBlock).Text;
                txtJumlahAnak.Text = (dgvKaryawan.SelectedCells[7].Column.GetCellContent(tampil) as TextBlock).Text;
            }
            else
            {
                txtNama.Text = "";
                txtEmail.Text = "";
                txtNoTelp.Text = "";
                txtJobTitle.Text = "";
                txtStatus.Text = "";
                txtJumlahAnak.Text = "";
            }
        }

        #endregion

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt16(txtIdKaryawan.Text);
            var employee = GetByIdKaryawan(Id);
            int Idd = Convert.ToInt16(cbDepartment.SelectedValue);
            var depid = context.Departments.Find(Idd);
            employee.Name = txtNama.Text;
            employee.Departments = depid;
            employee.Email = txtEmail.Text;
            employee.Telp = txtNoTelp.Text;
            employee.JobTitle = txtJobTitle.Text;
            employee.Status = txtStatus.Text;
            employee.TotalChilds = Convert.ToInt16(txtJumlahAnak.Text);
            context.Entry(employee).State = EntityState.Modified;
            context.SaveChanges();

            MessageBox.Show("Data Berhasil di Update!");
            TampilDataKaryawan();
        }
    }
}
