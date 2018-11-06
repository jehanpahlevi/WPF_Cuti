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
    /// Interaction logic for KaryawanForm.xaml
    /// </summary>
    public partial class KaryawanForm : Window
    {
        MyContext context = new MyContext();
        Employee employee = new Employee();
        //DateTime[] arrayOfOrgHolidays = new DateTime
        public KaryawanForm()
        {
            InitializeComponent();
        }
        

        private void buttonCancelLeave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void datepickerTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? startDate = datepickerFrom.SelectedDate;
            DateTime? endDate = datepickerTo.SelectedDate;
            TimeSpan total = (endDate - startDate).Value;
            var grandTotal = total.Days+1;

            if (grandTotal <= 5)
            {

            }
            else
            {
                MessageBox.Show("Cuti Maksimal 5 HARI!!!!!!");
                datepickerFrom.SelectedDate = DateTime.Now;
                datepickerTo.SelectedDate = DateTime.Now;
            }
        }

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
