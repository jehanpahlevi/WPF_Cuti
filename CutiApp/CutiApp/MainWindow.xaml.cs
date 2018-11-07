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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CutiApp.MyModel;

namespace CutiApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyContext context = new MyContext();
        Employee employee = new Employee();
        UserLog userlog = new UserLog();
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void buttonLogin_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void buttonLogin_Click(object sender, RoutedEventArgs e)
        //{
        //   if(emailTxt == )
        //}

        
        #region Button

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
=======
<<<<<<< HEAD

            var dataEmployee = context.Employees.Include("Departments").SingleOrDefault(x => x.Email == emailTxt.Text);
=======
<<<<<<< HEAD
            if (emailTxt.Text.Equals("") || passTxt.ToString() == "")
=======
>>>>>>> 4638aa192b5c9e94c6b3a07503f5e7f8140f208e
>>>>>>> d2a0ce5a1349f6e4a91423eb90f240e18b761bf4
            if (emailTxt.Text == "")
            {
                MessageBox.Show("PLEASE, FILL EMAIL FIRST!!!!");
            }
            else if (passTxt.Password == "")
            {
                MessageBox.Show("PLEASE, FILL PASSWORD FIRST!!!!");
            }
            else
            {
                    if (emailTxt.Text == dataEmployee.Email && passTxt.Password == dataEmployee.Password)
                    {
                        if (dataEmployee.Level == "Karyawan")
                        {
                        var getNameCompany = context.Departments.Include("Companies").SingleOrDefault(z => z.Name == dataEmployee.Departments.Name);
                        MessageBox.Show("Anda Masuk Sebagai Karyawan "+ dataEmployee.Name);
                            KaryawanForm karyawan = new KaryawanForm();
                            karyawan.txtNama.Text = dataEmployee.Name;
                            karyawan.txtDepartment.Text = dataEmployee.Departments.Name;
                            karyawan.txtCompany.Text = getNameCompany.Companies.Name;
                            karyawan.txtEmail.Text = dataEmployee.Email;
                            karyawan.txtJobTitle.Text = dataEmployee.JobTitle;
                            karyawan.txtID.Text = dataEmployee.Id.ToString();
                            karyawan.txtThisYear.Text = dataEmployee.ThisYearBalance.ToString();
                            karyawan.txtLastYear.Text = dataEmployee.LastYearBalance.ToString();
                            karyawan.Show();
                            this.Close();
                        }
                        else if(dataEmployee.Level == "Admin")
                        {
                        
                        MessageBox.Show("Anda Masuk Sebagai Admin " + dataEmployee.Name);
                            Master master = new Master();
                            master.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Anda Masuk Sebagai Manager " + dataEmployee.Name);
                            RMForm rmform = new RMForm();
                            rmform.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email atau Password Salah");
                    }
                
            }
        }

        #endregion Button
    }
}
