using AppSmartMailBox.Model;
using AppSmartMailBox.REST;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSmartMailBox
{
    public partial class App : Application
    {
        public static Utilisateur utilisateur { get; set; }

        public static RestService restService;
        public App()
        {
            InitializeComponent();
            Plugin.Iconize.Iconize.With(new PortailIcon.PortailIconModule());
            MainPage = new NavigationPage(new MainPage());
        }

        private static RestService _rest;

        public static RestService Rest
        {
            get
            {
                if (restService == null)
                {
                    restService = new RestService();
                }
                return restService;
            }
            set
            {
                _rest = value;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
