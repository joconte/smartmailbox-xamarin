using AppSmartMailBox.Model;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSmartMailBox.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccountPage : ContentPage
    {
        private readonly Utilisateur _utilisateur; 
        public CreateAccountPage()
        {
            InitializeComponent();
            _utilisateur = new Utilisateur();
            BindingContext = _utilisateur;
        }

        private async void Btn_Save_Clicked(object sender, EventArgs e)
        {
            var page = new UserAnimationPage();
            await PopupNavigation.Instance.PushAsync(page);
            if (!String.IsNullOrEmpty(Entry_password1.Text) && Entry_password1.Text == Entry_password2.Text)
            {
                password.IsVisible = false;
                _utilisateur.password = Entry_password1.Text;
                var utilisateurCreate = App.Rest.PostReponse<Utilisateur>(Constants.RegisterUtilisateur, JsonConvert.SerializeObject(_utilisateur));
                if (utilisateurCreate.Errors != null)
                {
                    foreach (KeyValuePair<string, List<string>> attr in utilisateurCreate.Errors)
                    {
                        Label label = Func.Func.FindControlByName<Label>(infoPersoStackLayout, attr.Key);
                        if (label != null)
                        {
                            foreach (var value in attr.Value)
                            {
                                label.Text += value;
                            }
                            label.IsVisible = true;
                        }
                    }
                }

                if (utilisateurCreate.t != null)
                {
                    var pageOk = new MisAJour("Votre compte a bien été créé. Veuillez consulter votre adresse email pour activer votre compte.",Color.Green);
                    await PopupNavigation.Instance.PushAsync(pageOk);
                    await Task.Delay(4000);
                    await PopupNavigation.Instance.PopAsync();
                    Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new NavigationPage(new MainPage()));
                    await PopupNavigation.Instance.PopAsync();
                }
                else
                {
                    var pageKo = new MisAJour("Erreur lors de la création de votre compte.", Color.Red);
                    await PopupNavigation.Instance.PushAsync(pageKo);
                    await Task.Delay(2000);
                    await PopupNavigation.Instance.PopAsync();
                    await PopupNavigation.Instance.PopAsync();
                }

            }
            else
            {
                password.IsVisible = true;
                password.Text = "Les deux mots de passes doivent être identiques.";
                await PopupNavigation.Instance.PopAsync();
            }
        }

    }
}