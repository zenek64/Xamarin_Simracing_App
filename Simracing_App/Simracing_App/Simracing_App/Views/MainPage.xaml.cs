﻿using Simracing_App.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Simracing_App
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }
        private void CalculatorButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CalculatorView());
        }
        private void TrackRecordsButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TrackRecordView());
        }
        
    }
}
