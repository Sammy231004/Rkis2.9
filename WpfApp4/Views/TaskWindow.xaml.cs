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
using WpfApp4.ViewModel;

namespace WpfApp4
{
 
    public partial class TaskWindow : Window
    {
        public TaskWindow()
        {
            InitializeComponent();
            DataContext = new TaskViewModel(); 
        }

        private void tasks_table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
