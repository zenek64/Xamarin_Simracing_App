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
        public int time;
        public int min;
        public int sec;
        public double fuel;
        public MainPage()
        {
            InitializeComponent();
        }

        private void HandleEnterPress(object sender, EventArgs e)
        {
            //Console.WriteLine("test");
            //result.Text= race_length.Text;

        }

        private void race_length_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Console.WriteLine(race_length.Text);
            //a = int.Parse(race_length.Text.ToString());
            //a++;
            //result.Text = a.ToString();

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
    }
}
