using Simracing_App.Data;
using Simracing_App.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Simracing_App.Views
{
    public partial class TrackRecordView : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public TrackRecordView()
        {
            InitializeComponent();

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            TrackRecordDB database = await TrackRecordDB.Instance;
            listView.ItemsSource = await database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TrackRecordItemView
            {
                BindingContext = new TrackRecord()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TrackRecordItemView
                {
                    BindingContext = e.SelectedItem as TrackRecord
                });
            }
        }

    }
}
