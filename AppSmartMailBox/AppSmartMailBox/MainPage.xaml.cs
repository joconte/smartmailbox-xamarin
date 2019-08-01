using AppSmartMailBox.Model;
using AppSmartMailBox.Views;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SmartMailBoxLib.REST;
using SmartMailBoxLib.Models;
using SmartMailBoxLib.Services;

namespace AppSmartMailBox
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        IAccountService accountService;
        IUtilisateurService utilisateurService;
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            Init();
            accountService = AccountServiceManager.GetAccountService();
            utilisateurService = UtilisateurServiceManager.GetUtilisateurService();
        }

        void Init()
        {
            LoginIcon.Source = ImageSource.FromResource("AppSmartMailBox.Resources.Images.MyDilLogo.png");

            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);

        }

        private async void SignInProcedure(object sender, EventArgs e)
        {
            var page = new UserAnimationPage();
            await PopupNavigation.Instance.PushAsync(page);
            Utilisateur utilisateur = new Utilisateur();
            utilisateur.email = Entry_Username.Text;
            utilisateur.password = Entry_Password.Text;
            try
            {
                await accountService.Login(utilisateur);

                GenericObjectWithErrorModel<Utilisateur> utilisateurWithError = utilisateurService.GetUtilisateurConnectedWithErrorModel();
                if (utilisateurWithError.t == null)
                {
                    throw new Exception("Utilisateur non trouvé");
                }
                App.Utilisateur = utilisateurWithError.t;
                Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new NavigationPage(new MasterPageDetail()));
                
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erreur", ex.Message, "OK");
            }
            finally
            {
                await PopupNavigation.Instance.PopAsync();
            }
        }

        private void Btn_CreateAccount_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateAccountPage());
        }


        private async void Btn_MdpOublie_Clicked(object sender, EventArgs e)
        {
            var page = new UserAnimationPage();
            await PopupNavigation.Instance.PushAsync(page);
            if (!string.IsNullOrEmpty(Entry_Username.Text))
            {
                var utilisateurCreate = accountService.PostForgotPassword(Entry_Username.Text);

                if (utilisateurCreate.t != null)
                {
                    var pageOk = new MisAJour("Veuillez consulter votre adresse email pour générer un nouveau mot de passe.", Color.Green);
                    await PopupNavigation.Instance.PushAsync(pageOk);
                    await Task.Delay(4000);
                    await PopupNavigation.Instance.PopAsync();
                    await PopupNavigation.Instance.PopAsync();
                }
                else
                {
                    var pageKo = new MisAJour("Email non trouvée.", Color.Red);
                    await PopupNavigation.Instance.PushAsync(pageKo);
                    await Task.Delay(2000);
                    await PopupNavigation.Instance.PopAsync();
                    await PopupNavigation.Instance.PopAsync();
                }

            }
            else
            {
                var pageKo = new MisAJour("Email obligatoire.", Color.Red);
                await PopupNavigation.Instance.PushAsync(pageKo);
                await Task.Delay(2000);
                await PopupNavigation.Instance.PopAsync();
                await PopupNavigation.Instance.PopAsync();
            }
        }
    }
}
