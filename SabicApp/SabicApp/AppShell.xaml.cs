using System;
using System.Collections.Generic;
using SabicApp.ViewModels;
using SabicApp.Views;
using Xamarin.Forms;

namespace SabicApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}


