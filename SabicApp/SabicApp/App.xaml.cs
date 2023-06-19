using System;
using Xamarin.Forms;
using SabicApp.Data;
using System.IO;

namespace SabicApp
{
    public partial class App : Application
    {
        static ItemsDatabase database;

        // Create the database connection as a singleton.
        public static ItemsDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ItemsDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Items.db3"));
                }
                return database;
            }
        }

        public App ()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}


