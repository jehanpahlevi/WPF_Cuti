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
    /// Interaction logic for RMForm.xaml
    /// </summary>
    public partial class RMForm : Window
    {
        MyContext myContext = new MyContext();
        EmployeeLeave employeeLeave = new EmployeeLeave(); 

        public RMForm()
        {
            InitializeComponent();
            TampilDataApprovalPage();
        }

        public EmployeeLeave GetByIdEmployeeLeave(int id)
        {
            return myContext.EmployeeLeaves.Find(id);
        }

        public void TampilDataApprovalPage()
        {
            try
            {
                var getData = myContext.EmployeeLeaves.Where(x => x.IsDelete == false).ToList();
                dgvApprovalPage.ItemsSource = getData;
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
        }

        private void btnAcceptLeave_Click(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt16(txtIdHistory.Text);
            var employeeleave = GetByIdEmployeeLeave(Id);
            employeeLeave.Status = "Accepted";
            myContext.Entry(employeeLeave).State = EntityState.Modified;
            myContext.SaveChanges();
        }

        private void btnRejectLeave_Click(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt16(txtIdHistory.Text);
            var employeeleave = GetByIdEmployeeLeave(Id);
            employeeLeave.Status = "Rejected";
            myContext.Entry(employeeLeave).State = EntityState.Modified;
            myContext.SaveChanges();
        }

        private void dgvApprovalPage_SelectionCellsChanged(object sender, SelectionChangedEventArgs e)
        {
            object tampil = dgvApprovalPage.SelectedItem;
            if (tampil != null)
            {
                txtSubmittedBy.Text = (dgvApprovalPage.SelectedCells[0].Column.GetCellContent(tampil) as TextBlock).Text;
                txtLeaveStatus.Text = (dgvApprovalPage.SelectedCells[2].Column.GetCellContent(tampil) as TextBlock).Text;
                txtRequestedDate.Text = (dgvApprovalPage.SelectedCells[1].Column.GetCellContent(tampil) as TextBlock).Text;
            }
            else
            {
                txtSubmittedBy.Text = "";
                txtLeaveStatus.Text = "";
                txtRequestedDate.Text = "";
            }
        }
    }
}
