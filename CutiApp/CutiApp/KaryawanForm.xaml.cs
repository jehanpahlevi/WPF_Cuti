﻿using System;
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
        public KaryawanForm()
        {
            InitializeComponent();
        }
        

        private void buttonCancelLeave_Click(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
