using AppSmartMailBox.Model;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSmartMailBox.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfosPersonnellesPage : ContentPage
    {
        private Utilisateur utilisateur;
        public InfosPersonnellesPage()
        {
            InitializeComponent();
            utilisateur = App.utilisateur;
            BindingContext = utilisateur;
        }

        private async void Btn_Save_Clicked(object sender, EventArgs e)
        {
            var page = new UserAnimationPage();
            await PopupNavigation.Instance.PushAsync(page);
            if ((!String.IsNullOrEmpty(Entry_password1.Text) && Entry_password1.Text == Entry_password2.Text) || (String.IsNullOrEmpty(Entry_password1.Text) && String.IsNullOrEmpty(Entry_password2.Text) ) )
            {
                password.IsVisible = false;
                utilisateur.password = Entry_password1.Text;
                Utilisateur newUtilisateur = new Utilisateur();
                newUtilisateur.firstName = utilisateur.firstName;
                newUtilisateur.lastName = utilisateur.lastName;
                newUtilisateur.email = utilisateur.email;
                newUtilisateur.password = utilisateur.password;
                

                var utilisateurCreate = App.Rest.PutResponse<Utilisateur>(Constants.UpdateUser, JsonConvert.SerializeObject(newUtilisateur));
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
                    var pageOk = new MisAJour("Vos informations ont bien été mises à jour.", Color.Green);
                    await PopupNavigation.Instance.PushAsync(pageOk);
                    App.utilisateur = utilisateurCreate.t;
                    await Task.Delay(2000);
                    await PopupNavigation.Instance.PopAsync();
                    Device.BeginInvokeOnMainThread(() => App.Current.MainPage = new NavigationPage(new MasterPageDetail()));
                    await PopupNavigation.Instance.PopAsync();
                }
                else
                {
                    var pageKo = new MisAJour("Erreur lors de la mise à jour de vos informations.", Color.Red);
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