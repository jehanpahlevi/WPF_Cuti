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
                var dataEmployee = context.Employees.Where(x => x.Email == emailTxt.Text).ToList();
                foreach (var value in dataEmployee)
                {
                    if (emailTxt.Text == value.Email && passTxt.Password == value.Password)
                    {
                        if (value.Level == "Karyawan")
                        {
                            MessageBox.Show("Anda Masuk Sebagai Karyawan "+value.Name);
                            KaryawanForm karyawan = new KaryawanForm();
                            karyawan.txtNama.Text = value.Name;
                            //karyawan.txtDepartment.Text = value.Departments.ToString();
                            karyawan.txtEmail.Text = value.Email;
                            karyawan.txtJobTitle.Text = value.JobTitle;
                            karyawan.txtID.Text = value.Id.ToString();
                            karyawan.txtThisYear.Text = value.ThisYearBalance.ToString();
                            karyawan.Show();
                            this.Close();
                        }
                        else if(value.Level == "Admin")
                        {
                            MessageBox.Show("Anda Masuk Sebagai Admin " + value.Name);
                            Master master = new Master();
                            master.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Anda Masuk Sebagai Manager " + value.Name);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email atau Password Salah");
                    }
                }
            }
        }

        #endregion Button
    }
}
