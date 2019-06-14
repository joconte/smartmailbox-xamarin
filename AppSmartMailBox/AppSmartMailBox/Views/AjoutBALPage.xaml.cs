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
    public partial class AjoutBALPage : ContentPage
    {
        public AjoutBALPage()
        {
            InitializeComponent();
        }

        private async void AddBAL(object sender, EventArgs e)
        {
            var page = new UserAnimationPage();
            await PopupNavigation.Instance.PushAsync(page);
            BoiteAuLettre boiteAuLettre = new BoiteAuLettre
            {
                numeroSerie = Entry_numSerie.Text, description = Entry_descriptionBAL.Text
            };
            if (!String.IsNullOrEmpty(boiteAuLettre.numeroSerie))
            {
                var utilisateurUpdated = App.Rest.PostReponse<Utilisateur>(Constants.AddBalToCurrentUser, JsonConvert.SerializeObject(boiteAuLettre));
                if (utilisateurUpdated.t != null)
                {
                    var pageOk = new MisAJour("La boite aux lettres a été ajouté.", Color.Green);
                    await PopupNavigation.Instance.PushAsync(pageOk);
                    await Task.Delay(2000);
                    await PopupNavigation.Instance.PopAsync();
                    App.Utilisateur.boiteAuLettres = utilisateurUpdated.t.boiteAuLettres;
                    await PopupNavigation.Instance.PopAsync();
                }
                else
                {
                    string message = "";
                    foreach (KeyValuePair<string, List<string>> attr in utilisateurUpdated.Errors)
                    {
                        foreach (var value in attr.Value)
                        {
                            message += value;
                        }
                    }
                    var pageKo = new MisAJour(message, Color.Red);
                    await PopupNavigation.Instance.PushAsync(pageKo);
                    await Task.Delay(2000);
                    await PopupNavigation.Instance.PopAsync();
                    await PopupNavigation.Instance.PopAsync();
                }
            }
            else
            {
                var pageKo = new MisAJour("Le numéro de série est obligatoire", Color.Red);
                await PopupNavigation.Instance.PushAsync(pageKo);
                await Task.Delay(2000);
                await PopupNavigation.Instance.PopAsync();
                await PopupNavigation.Instance.PopAsync();
            }
        }
    }
}