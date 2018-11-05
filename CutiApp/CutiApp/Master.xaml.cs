using System;
using System.Collections.Generic;
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
        }

        #region Karyawan

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
        }

        #endregion
    }
}
