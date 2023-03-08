using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using static Xamarin.Forms.Internals.Profile;

namespace Examen
{
    public partial class App : Application
    {
        static Controllers.DataControllers dbdata;

        public static Controllers.DataControllers DBdata

        {
            get
            {
                if (dbdata == null)
                {
                    var dbpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var dbname = "Data.db3";
                    dbdata = new Controllers.DataControllers(Path.Combine(dbpath, dbname));
                }

                return dbdata;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
