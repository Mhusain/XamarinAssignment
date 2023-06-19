using System;
using System.Collections.Generic;
using SabicApp.ViewModels;
using Xamarin.Forms;

namespace SabicApp.Views
{	
	public partial class AudioPage : ContentPage
	{

		private AudioViewModel viewModel;

		public AudioPage ()
		{
			InitializeComponent ();

            viewModel = (AudioViewModel)BindingContext;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.CheckAndRequestPermissions();
        }
    }
}

