using Simracing_App.Views;
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
        private int time;
        private int min;
        private int sec;
        private double fuel;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            time = int.Parse(race_length.Text.ToString());
            min = int.Parse(lap_time_min.Text.ToString());
            sec = int.Parse(lap_time_sec.Text.ToString());
            fuel = double.Parse(fuel_per_lap.Text.ToString());

            double minimum;
            double recommended;
            double safe;

            minimum = (((time * 60) / ((min * 60) + sec)) * fuel) + fuel;
            recommended = (((time * 60) / ((min * 60) + sec)) * fuel) + (fuel * 2);
            safe = (((time * 60) / ((min * 60) + sec)) * fuel) + (fuel * 3);

            result.Text = minimum.ToString();
            result_rec.Text = recommended.ToString();
            result_safe.Text = safe.ToString();
        }
        private void OnButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TrackRecordView());
        }
    }
}
