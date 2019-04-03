﻿using Currency_Object_Model_Midterm.Models;
using Currency_Object_Model_Midterm.ViewModels;
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

namespace Currency_Object_Model_Midterm.Views
{
    /// <summary>
    /// Interaction logic for UserControlCurrency.xaml
    /// </summary>
    public partial class UserControlCurrency : UserControl
    {
        public UserControlCurrency()
        {
            InitializeComponent();
            CurrencyRepo repo = new CurrencyRepo();
            ViewModelMakeChangeUI makeChangeModel = new ViewModelMakeChangeUI(repo);
            this.DataContext = makeChangeModel;
        }
    }
}