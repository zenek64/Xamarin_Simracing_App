using Simracing_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simracing_App.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Simracing_App.Views
{
	public partial class TrackRecordItemView 
	{
		public TrackRecordItemView()
		{
			InitializeComponent();
		}
        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (TrackRecord)BindingContext;
            TrackRecordDB database = await TrackRecordDB.Instance;
            await database.SaveItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (TrackRecord)BindingContext;
            TrackRecordDB database = await TrackRecordDB.Instance;
            await database.DeleteItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}