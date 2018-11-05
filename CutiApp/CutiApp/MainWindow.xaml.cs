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

        #region Find Employee
        public Employee getDataEmployee(string email)
        {
            return context.Employees.;
        }
        #endregion Find Employee

        #region Button

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            if(emailTxt.Text == "" || passTxt.ToString() == "")
            {
                MessageBox.Show("PLEASE, FILL EMAIL AND PASSWORD FIRST!!!!");
            }
            else
            {

                var dataEmployee = getDataEmployee(emailTxt.Text);
                if (emailTxt.Text == dataEmployee.Email.ToString() && passTxt.ToString() == dataEmployee.Password.ToString())
                {
                    MessageBox.Show("SUKSES");
                }
            }
        }

        #endregion Button
    }
}
