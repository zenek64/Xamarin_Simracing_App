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
            _time = int.Parse(race_length.Text.ToString());
            _min = int.Parse(lap_time_min.Text.ToString());
            _sec = int.Parse(lap_time_sec.Text.ToString());
            _fuel = double.Parse(fuel_per_lap.Text.ToString());

            double minimum;
            double recommended;
            double safe;

            minimum = (((_time * 60) / ((_min * 60) + _sec)) * _fuel) + _fuel;
            recommended = minimum + _fuel;
            safe = recommended + _fuel;

            result.Text = minimum.ToString();
            result_rec.Text = recommended.ToString();
            result_safe.Text = safe.ToString();
        }  
    }
}