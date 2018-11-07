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
        Company company = new Company();
        Leave leave = new Leave();

        public Master()
        {
            InitializeComponent();
            TampilDataKaryawan();
            TampilDataCompany();
            TampilDataDepartment();
            TampilDataLeave();
            tampilcbcompany();
            tampilcbmanager();
            tampilcbdepartment();
        }

        public void tampilcbcompany()
        {
            int Id = Convert.ToInt16(cbCompany.SelectedValue);
            var getData = context.Companies.ToList();
            cbCompany.ItemsSource = getData;
        }

        public void tampilcbmanager()
        {
            int Id = Convert.ToInt16(cbManager.SelectedValue);
            var getData = context.Employees.Where(x => x.Level == "Manager").ToList();
            cbManager.ItemsSource = getData;
        }

        public void tampilcbdepartment()
        {
            int id = Convert.ToInt16(cbDepartment.SelectedValue);
            var getData = context.Departments.ToList();
            cbDepartment.ItemsSource = getData;
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
            employee.Level = cbLevel.Text;
            context.Employees.Add(employee);
            context.SaveChanges();

            MessageBox.Show("Data berhasil disimpan!");
            TampilDataKaryawan();
            TampilDataCompany();
            TampilDataDepartment();
            TampilDataLeave();
            tampilcbcompany();
            tampilcbmanager();
            tampilcbdepartment();
        }


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
            employee.Level = cbLevel.Text;
            context.Entry(employee).State = EntityState.Modified;
            context.SaveChanges();

            MessageBox.Show("Data Berhasil diupdate!");
            TampilDataKaryawan();
            TampilDataCompany();
            TampilDataDepartment();
            TampilDataLeave();
            tampilcbcompany();
            tampilcbmanager();
            tampilcbdepartment();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt16(txtIdKaryawan.Text);
            var employee = GetByIdKaryawan(Id);
            employee.IsDelete = true;
            context.Entry(employee).State = EntityState.Modified;
            context.SaveChanges();

            MessageBox.Show("Data Berhasil dihapus!");
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
                cbLevel.Text = (dgvKaryawan.SelectedCells[8].Column.GetCellContent(tampil) as TextBlock).Text;
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

        #region Company

        public Company GetByIdCompany(int id)
        {
            return context.Companies.Find(id);
        }

        public void TampilDataCompany()
        {
            var getData = context.Companies.Where(x => x.IsDelete == false).ToList();
            dgvCompany.ItemsSource = getData;
        }

        private void btnSaveCompany_Click(object sender, RoutedEventArgs e)
        {
            company.Name = txtNamaCompany.Text;
            context.Companies.Add(company);
            context.SaveChanges();

            MessageBox.Show("Data berhasil disimpan!");
            TampilDataKaryawan();
            TampilDataCompany();
            TampilDataDepartment();
            TampilDataLeave();
            tampilcbcompany();
            tampilcbmanager();
            tampilcbdepartment();
        }

        private void btnUpdateCompany_Click(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt16(txtIdCompany.Text);
            var company = GetByIdCompany(Id);
            company.Name = txtNamaCompany.Text;
            context.Entry(company).State = EntityState.Modified;
            context.SaveChanges();

            MessageBox.Show("Data Berhasil diupdate!");
            TampilDataKaryawan();
            TampilDataCompany();
            TampilDataDepartment();
            TampilDataLeave();
            tampilcbcompany();
            tampilcbmanager();
            tampilcbdepartment();
        }

        private void btnDeleteCompany_Click(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt16(txtIdCompany.Text);
            var company = GetByIdCompany(Id);
            company.IsDelete = true;
            context.Entry(company).State = EntityState.Modified;
            context.SaveChanges();

            MessageBox.Show("Data Berhasil dihapus!");
            TampilDataKaryawan();
            TampilDataCompany();
            TampilDataDepartment();
            TampilDataLeave();
            tampilcbcompany();
            tampilcbmanager();
            tampilcbdepartment();
        }

        private void dgvCompany_SelectionCellsChanged(object sender, SelectionChangedEventArgs e)
        {
            object tampil = dgvCompany.SelectedItem;
            if (tampil != null)
            {
                txtIdCompany.Text = (dgvCompany.SelectedCells[0].Column.GetCellContent(tampil) as TextBlock).Text;
                txtNamaCompany.Text = (dgvCompany.SelectedCells[1].Column.GetCellContent(tampil) as TextBlock).Text;
            }
            else
            {
                txtIdCompany.Text = "";
                txtNamaCompany.Text = "";
            }
        }

        #endregion

        #region Department

        public Department GetByIdDepartment(int id)
        {
            return context.Departments.Find(id);
        }

        public void TampilDataDepartment()
        {
            try
            {
                var getData = context.Departments.Where(x => x.IsDelete == false).ToList();
                dgvDepartment.ItemsSource = getData;
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }

        }

        private void btnSaveDept_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt16(cbCompany.SelectedValue);
            var comp = context.Companies.Find(id);
            int idm = Convert.ToInt16(cbManager.SelectedValue);
            var mang = context.Employees.Find(idm);
            department.Name = txtNamaDepartment.Text;
            department.Companies = comp;
            department.ManagerId = mang.Id;
            context.Departments.Add(department);
            context.SaveChanges();

            MessageBox.Show("Data berhasil disimpan!");
            TampilDataKaryawan();
            TampilDataCompany();
            TampilDataDepartment();
            TampilDataLeave();
            tampilcbcompany();
            tampilcbmanager();
            tampilcbdepartment();
        }

        private void dgvDepartment_SelectionCellsChanged(object sender, SelectionChangedEventArgs e)
        {
            object tampil = dgvDepartment.SelectedItem;
            if (tampil != null)
            {
                txtIdDepartment.Text = (dgvDepartment.SelectedCells[0].Column.GetCellContent(tampil) as TextBlock).Text;
                txtNamaDepartment.Text = (dgvDepartment.SelectedCells[1].Column.GetCellContent(tampil) as TextBlock).Text;
                cbCompany.Text = (dgvDepartment.SelectedCells[2].Column.GetCellContent(tampil) as TextBlock).Text;
                cbManager.Text = (dgvDepartment.SelectedCells[3].Column.GetCellContent(tampil) as TextBlock).Text;
            }
            else
            {
                txtIdCompany.Text = "";
                txtNamaCompany.Text = "";
                cbCompany.Text = "";
                cbManager.Text = "";
            }
        }

        private void btnUpdateDept_Click(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt16(txtIdDepartment.Text);
            var department = GetByIdDepartment(Id);
            int id = Convert.ToInt16(cbCompany.SelectedValue);
            var comp = context.Companies.Find(id);
            int idm = Convert.ToInt16(cbManager.SelectedValue);
            var mang = context.Employees.Find(idm);
            department.Name = txtNamaDepartment.Text;
            department.Companies = comp;
            department.ManagerId = mang.Id;

            context.Entry(department).State = EntityState.Modified;
            context.SaveChanges();
            MessageBox.Show("Data berhasil diupdate!");
            TampilDataKaryawan();
            TampilDataCompany();
            TampilDataDepartment();
            TampilDataLeave();
            tampilcbcompany();
            tampilcbmanager();
            tampilcbdepartment();
        }

        private void btnDeleteDept_Click(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt16(txtIdDepartment.Text);
            department.IsDelete = true;

            context.Entry(department).State = EntityState.Modified;
            context.SaveChanges();
            MessageBox.Show("Data berhasil diupdate!");
            TampilDataKaryawan();
            TampilDataCompany();
            TampilDataDepartment();
            TampilDataLeave();
            tampilcbcompany();
            tampilcbmanager();
            tampilcbdepartment();
        }

        #endregion

        public Leave GetByIdLeave(int id)
        {
            return context.Leaves.Find(id);
        }

        public void TampilDataLeave()
        {
            var getData = context.Leaves.Where(x => x.IsDelete == false).ToList();
            dgvLeave.ItemsSource = getData;
        }

        private void btnUpdateLeave_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt16(txtIdLeave.Text);
            var leave = GetByIdLeave(id);
            leave.LeaveType = txtJenisCuti.Text;
            leave.LengthDays = Convert.ToInt16(txtLamaHari.Text);

            context.Entry(leave).State = EntityState.Modified;
            context.SaveChanges();
            MessageBox.Show("Data berhasil diupdate!");
            TampilDataLeave();
        }

        private void btnDeleteLeave_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt16(txtIdLeave.Text);
            var leave = GetByIdLeave(id);
            leave.IsDelete = true;

            context.Entry(leave).State = EntityState.Modified;
            context.SaveChanges();
            MessageBox.Show("Data berhasil diupdate!");
            TampilDataLeave();
        }

        private void btnSaveLeave_Click(object sender, RoutedEventArgs e)
        {
            leave.LeaveType = txtJenisCuti.Text;
            leave.LengthDays = Convert.ToInt16(txtLamaHari.Text);

            context.Leaves.Add(leave);
            context.SaveChanges();
            MessageBox.Show("Data berhasil disimpan!");
            TampilDataLeave();
        }

        private void dgvLeave_SelectionCellsChanged(object sender, SelectionChangedEventArgs e)
        {
            object tampil = dgvLeave.SelectedItem;
            if (tampil != null)
            {
                txtIdLeave.Text = (dgvLeave.SelectedCells[0].Column.GetCellContent(tampil) as TextBlock).Text;
                txtJenisCuti.Text = (dgvLeave.SelectedCells[1].Column.GetCellContent(tampil) as TextBlock).Text;
                txtLamaHari.Text = (dgvLeave.SelectedCells[2].Column.GetCellContent(tampil) as TextBlock).Text;
            }
            else
            {
                txtIdLeave.Text = "";
                txtJenisCuti.Text = "";
                txtLamaHari.Text = "";
            }
        }
    }
}
