using System;
using System.Collections.ObjectModel;
using SabicApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SabicApp.Views
{
    public partial class MapPage : ContentPage
    {

        public MapPage()
        {
            InitializeComponent();

            BindingContext = new MapViewModel();
        }

        void map_MapClicked(System.Object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
        }
    }
}

