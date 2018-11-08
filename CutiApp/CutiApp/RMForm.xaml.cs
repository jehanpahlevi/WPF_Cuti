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
        MyContext context = new MyContext();
        EmployeeLeave employeeLeave = new EmployeeLeave();
        Employee employee = new Employee();

        public RMForm()
        {
            InitializeComponent();
            TampilDataApprovalPage();
        }

        public EmployeeLeave GetByIdEmployeeLeave(int id)
        {
            return context.EmployeeLeaves.Find(id);
        }

        public void TampilDataApprovalPage()
        {
            try
            {
                var getData = context.EmployeeLeaves.Include("Employees").Where(x => x.Status == "Submitted").ToList();
                dgvApprovalPage.ItemsSource = getData;
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
            }
        }

        private void btnAcceptLeave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = Convert.ToInt16(txtIdHistory.Text);
                var employeeleave = GetByIdEmployeeLeave(Id);
                employeeleave.Status = "Accepted";
                context.Entry(employeeleave).State = EntityState.Modified;
                context.SaveChanges();

                MessageBox.Show("Cuti disetujui.");
                TampilDataApprovalPage();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
            }
        }

        private void btnRejectLeave_Click(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt16(txtIdHistory.Text);
            var employeeleave = GetByIdEmployeeLeave(Id);
            employeeleave.Status = "Rejected";
            context.Entry(employeeleave).State = EntityState.Modified;
            context.SaveChanges();

            MessageBox.Show("Cuti ditolak.");
            TampilDataApprovalPage();
        }

        private void dgvApprovalPage_SelectionCellsChanged(object sender, SelectionChangedEventArgs e)
        {
            object tampil = dgvApprovalPage.SelectedItem;
            if (tampil != null)
            {
                txtIdHistory.Text = (dgvApprovalPage.SelectedCells[0].Column.GetCellContent(tampil) as TextBlock).Text;
                txtSubmittedBy.Text = (dgvApprovalPage.SelectedCells[1].Column.GetCellContent(tampil) as TextBlock).Text;
                txtRequestedDate.Text = (dgvApprovalPage.SelectedCells[2].Column.GetCellContent(tampil) as TextBlock).Text;
                txtNote.Text = (dgvApprovalPage.SelectedCells[4].Column.GetCellContent(tampil) as TextBlock).Text;
                txtTotalDays.Text = (dgvApprovalPage.SelectedCells[3].Column.GetCellContent(tampil) as TextBlock).Text;
            }
            else
            {
                txtIdHistory.Text = "";
                txtSubmittedBy.Text = "";
                txtNote.Text = "";
                txtRequestedDate.Text = "";
            }
        }
    }
}
