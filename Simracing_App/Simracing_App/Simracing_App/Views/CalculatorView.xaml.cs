using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Simracing_App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalculatorView : ContentPage
	{
        private int _time;
        private int _min;
        private int _sec;
        private double _fuel;
        public CalculatorView()
		{
			InitializeComponent();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            _time = SetTime(race_length.Text.ToString());
            _min = SetTime(lap_time_min.Text.ToString());
            _sec = SetTime(lap_time_sec.Text.ToString());
            _fuel = SetFuel(fuel_per_lap.Text.ToString());

            double minimum = CalculateFuel(_time, _min, _sec, _fuel);
            double recommended = CalculateFuel(_time, _min, _sec, _fuel) + _fuel;
            double safe = CalculateFuel(_time, _min, _sec, _fuel) + (2 * _fuel);

            result.Text = minimum.ToString();
            result_rec.Text = recommended.ToString();
            result_safe.Text = safe.ToString();
        }
        
        private double CalculateFuel(int time, int min, int sec, double fuel)
        {
            double reqFuel;

            reqFuel = (((time * 60) / ((min * 60) + sec)) * fuel) + fuel;

            return reqFuel;
        }
        private int SetTime(string n)
        {
            int number;

            bool success = int.TryParse(n, out number);
            if (success)
            {
                return number;
            }
            else
            {
                number = 1;
                return number;
            }
        }
        private double SetFuel(string n) 
        {
            double number;
            
            bool success = double.TryParse(n, out number);
            if(success)
            {
                return number;
            }
            else
            { 
                number = 1; 
                return number; 
            }
        }
    }
}