using SmartMailBoxLib.Models;
using SmartMailBoxLib.REST;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSmartMailBox
{
    public partial class App : Application
    {
        public static Utilisateur Utilisateur { get; set; }

        
        public App()
        {
            InitializeComponent();
            Plugin.Iconize.Iconize.With(new PortailIcon.PortailIconModule());
            Constants.IsMocked = false;
            MainPage = new NavigationPage(new MainPage());
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
