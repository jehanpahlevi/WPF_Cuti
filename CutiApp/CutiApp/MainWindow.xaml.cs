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

        
        #region Button

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (emailTxt.Text == "" || passTxt.ToString() == "")
            {
                MessageBox.Show("PLEASE, FILL EMAIL AND PASSWORD FIRST!!!!");
            }
            else
            {
                var dataEmployee = context.Employees.Where(x => x.Email == emailTxt.Text).ToList();
                foreach (var value in dataEmployee)
                {
                    if (emailTxt.Text == value.Email || passTxt.ToString() == value.Password)
                    {
                        if (value.Level == "karyawan")
                        {
                            MessageBox.Show("Anda Masuk Sebagai Karyawan "+value.Name);
                        }
                        else if(value.Level == "admin")
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
                }
            }
        }

        #endregion Button
    }
}
