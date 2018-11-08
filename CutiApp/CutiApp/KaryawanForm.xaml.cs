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
    /// Interaction logic for KaryawanForm.xaml
    /// </summary>
    public partial class KaryawanForm : Window
    {
        MyContext context = new MyContext();
        Employee employee = new Employee();
        Leave leave = new Leave();
        EmployeeLeave employeeleave = new EmployeeLeave();

        DateTime? start = null;
        DateTime? end = null;
        int hasilkurangthis;
        int hasilkuranglast;
        public KaryawanForm()
        {
            InitializeComponent();
            loadComboBoxSpecialDay();
            TampilDataHistory();
        }


        private void buttonCancelLeave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void datepickerTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? startDate = datepickerFrom.SelectedDate;
            DateTime? endDate = datepickerTo.SelectedDate;
            datepickerFrom_Copy.SelectedDate = datepickerTo.SelectedDate.Value.AddDays(1);
            TimeSpan total = (endDate - startDate).Value;
            int thisY = Convert.ToUInt16(txtThisYear.Text);
            var grandTotal = total.Days + 1;

            if (grandTotal <= 5 && grandTotal <= thisY && thisY != 0)
            {
                annualLeaveDay.Text = grandTotal.ToString();
                annualLeaveDayCalendar.Text = grandTotal.ToString();
                annualLeaveDayTotal.Text = grandTotal.ToString();
            }
            else
            {
                MessageBox.Show("Cuti Maksimal 5 HARI!!!!!!");
                datepickerFrom.SelectedDate = DateTime.Now;
                datepickerTo.SelectedDate = DateTime.Now;
            }
        }

        public void loadComboBoxSpecialDay()
        {
            var getData = context.Leaves.Where(x => x.IsDelete == false).ToList();
            comboBoxSpecialDay.ItemsSource = getData;
        }

        private void comboBoxSpecialDay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ID = Convert.ToInt16(comboBoxSpecialDay.SelectedValue);
            var getLengthDay = context.Leaves.SingleOrDefault(x => x.Id == ID);
            if (getLengthDay.LengthDays != 0)
            {

                specialLeaveDay.Text = getLengthDay.LengthDays.ToString();
                int annualLeave = Convert.ToInt16(annualLeaveDayTotal.Text);
                int totalDays = getLengthDay.LengthDays;
                double addDay = Convert.ToDouble(specialLeaveDay.Text);
                datepickerTo_Copy.SelectedDate = datepickerFrom_Copy.SelectedDate.Value.AddDays(addDay - 1);
                annualLeaveDayTotal.Text = (annualLeave + totalDays).ToString();

            }
            else
            {
                specialLeaveDay.Text = "";
                annualLeaveDay.Text = "";
                annualLeaveDayCalendar.Text = "0";
                annualLeaveDayTotal.Text = "0";

            }
        }

        private void annualLeaveDay_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (annualLeaveDay.Text == "")
            {
                annualLeaveDay.Text = "0";
            }

        }

        private void specialLeaveDay_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (specialLeaveDay.Text == "")
            {
                specialLeaveDay.Text = "0";
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            
            if (annualLeaveDayTotal.Text == "0")
            {
                MessageBox.Show("Isi Data Sesuai Form!!");
            }
            else
            {
                if (datepickerFrom.Text != DateTime.Now.Date.ToString() && datepickerFrom_Copy.Text != DateTime.Now.Date.ToString())
                {
                    var dateAnnual = datepickerFrom.SelectedDate;
                    var dateSpecial = datepickerFrom_Copy.SelectedDate;
                    var endateAnnual = datepickerTo.SelectedDate;
                    var endateSpecial = datepickerTo_Copy.SelectedDate;
                    int totaldays = Convert.ToInt16(annualLeaveDayTotal.Text);
                    if (dateSpecial == null)
                    {
                        start = dateAnnual;
                    }
                    else if (dateAnnual == null)
                    {
                        start = dateSpecial;
                    }
                    else if (dateAnnual != null && dateSpecial != null && dateAnnual < dateSpecial)
                    {
                        start = Convert.ToDateTime(dateAnnual);
                    }
                    else if (dateAnnual != null && dateSpecial != null && dateAnnual > dateSpecial)
                    {
                        start = Convert.ToDateTime(dateSpecial);
                    }
                    if (endateAnnual == null)
                    {
                        end = endateSpecial;
                    }
                    else if (endateSpecial == null)
                    {
                        end = endateAnnual;
                    }
                    else if (endateAnnual != null && endateSpecial != null && endateAnnual > endateSpecial)
                    {
                        end = Convert.ToDateTime(endateAnnual);
                    }
                    else if (endateAnnual != null && endateSpecial != null && endateAnnual < endateSpecial)
                    {
                        end = Convert.ToDateTime(endateSpecial);
                    }

                    InsertCuti(start, end, totaldays, "Submitted", DateTimeOffset.Now.LocalDateTime);


                    //int lastbalance = Convert.ToInt16(txtLastYear.Text);
                    //int thisbalance = Convert.ToInt16(txtThisYear.Text);
                    //var editbalance = GetById(Convert.ToInt16(txtID.Text));
                    //if (editbalance != null)
                    //{
                    //    if (txtLastYear.Text == "0")
                    //    {
                    //        int totalhol = Convert.ToUInt16(annualLeaveDayCalendar.Text);
                    //        hasilkurangthis = thisbalance - totalhol;
                    //        employee.ThisYearBalance = hasilkurangthis;
                    //    }
                    //    else if (lastbalance > Convert.ToInt16(annualLeaveDayCalendar.Text))
                    //    {
                    //        hasilkuranglast = lastbalance - Convert.ToInt16(annualLeaveDayCalendar.Text);
                    //        employee.LastYearBalance = hasilkuranglast;
                    //    }
                    //    else if (lastbalance < Convert.ToInt16(annualLeaveDayCalendar.Text))
                    //    {
                    //        int totalhol = Convert.ToUInt16(annualLeaveDayCalendar.Text);
                    //        int nol = totalhol - lastbalance;
                    //        int totalakhir = thisbalance - nol;
                    //        employee.ThisYearBalance = totalakhir;
                    //        employee.LastYearBalance = 0;
                    //    }
                    //    employee.UpdateDate = DateTimeOffset.Now.LocalDateTime;
                    //    context.Entry(employee).State = EntityState.Modified;
                    //    context.SaveChanges();
                    //}


                    MessageBox.Show("Permohonan Cuti Berhasil Diajukan");
                    TampilDataHistory();
                }
                else
                {
                    MessageBox.Show("Isi tanggal Mulai Cuti!!");
                }

            }
        }

        private void datepickerFrom_Copy_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            double addDay = Convert.ToDouble(specialLeaveDay.Text);
            datepickerTo_Copy.SelectedDate = datepickerFrom_Copy.SelectedDate.Value.AddDays(addDay);
        }

        public Employee GetById(int id)
        {
            return context.Employees.Find(id);
        }

        public void InsertCuti(DateTime? start, DateTime? end, int totalDays, string status, DateTimeOffset createdate)
        {
            employeeleave.StartDate = start;
            employeeleave.EndDate = end;
            employeeleave.TotalDays = totalDays;
            employeeleave.Status = status;
            employeeleave.CreateDate = createdate;
            int ID = Convert.ToInt16(txtID.Text);
            var getEmployee = context.Employees.Find(ID);
            employeeleave.Employees = getEmployee;
            int IdLeave = Convert.ToInt16(comboBoxSpecialDay.SelectedValue);
            var getLeave = context.Leaves.Find(IdLeave);
            employeeleave.Leaves = getLeave;
            context.EmployeeLeaves.Add(employeeleave);
            context.SaveChanges();
        }

        public EmployeeLeave GetByIdEmployee(int id)
        {
            return context.EmployeeLeaves.Find(id);
        }

        public void TampilDataHistory()
        {
            try
            {
                var getData = context.EmployeeLeaves.Include("Employees").Where(x => x.IsDelete == false).ToList();
                dgvHistoryKaryawan.ItemsSource = getData;
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt16(txtIdLeavesDetail.Text);
            var employeeleave = GetByIdEmployee(Id);
            employeeleave.Status = "Canceled";
            context.Entry(employeeleave).State = EntityState.Modified;
            context.SaveChanges();

            MessageBox.Show("Cuti dibatalkan.");
            TampilDataHistory();
        }

        private void dgvHistoryKaryawan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object tampil = dgvHistoryKaryawan.SelectedItem;
            if (tampil != null)
            {
                txtIdLeavesDetail.Text = (dgvHistoryKaryawan.SelectedCells[0].Column.GetCellContent(tampil) as TextBlock).Text;
                txtSubmittedBy.Text = (dgvHistoryKaryawan.SelectedCells[1].Column.GetCellContent(tampil) as TextBlock).Text;
                txtRequestedDate.Text = (dgvHistoryKaryawan.SelectedCells[2].Column.GetCellContent(tampil) as TextBlock).Text;
                txtNote.Text = (dgvHistoryKaryawan.SelectedCells[4].Column.GetCellContent(tampil) as TextBlock).Text;
                txtTotalDays.Text = (dgvHistoryKaryawan.SelectedCells[3].Column.GetCellContent(tampil) as TextBlock).Text;
            }
            else
            {
                txtSubmittedBy.Text = "";
                txtNote.Text = "";
                txtRequestedDate.Text = "";
            }
        }
        //public int loadThisLastBalance(int Id)
        //{
        //    var getThisLast = context.Employees.Find(Id);
        //    return getThisLast.ThisYearBalance;
        //}

        //private int WorkingDays(DateTime startDate, DateTime endDate)
        //{
        //    int noOfDays = 0;
        //    int count = 0;
        //    if (DateTime.Compare(startDate, endDate) == 1)
        //        MessageBox.Show("Masukkan tanggal \" Start Date < End Date \" !", "Alert", MessageBoxButton.OK);
        //    while (DateTime.Compare(startDate, endDate) <= 0)
        //    {
        //        if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
        //        {
        //            string holiday = (from date in arrayOfOrgHolidays where DateTime.Compare(startDate, date) == 0 select "Holiday").Firs
        //        }
        //    }
        //}
    }
}
