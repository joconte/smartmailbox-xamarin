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
    public partial class CreateBALPage : ContentPage
    {
        public CreateBALPage()
        {
            InitializeComponent();
        }

        private async void CreateBAL(object sender, EventArgs e)
        {
            var page = new UserAnimationPage();
            await PopupNavigation.Instance.PushAsync(page);
            BoiteAuLettre boiteAuLettre = new BoiteAuLettre {numeroSerie = Entry_numSerie.Text};
            if (!String.IsNullOrEmpty(boiteAuLettre.numeroSerie))
            {
                var boiteAuLettreCreated = App.Rest.PostReponse<BoiteAuLettre>(Constants.CreateBAL, JsonConvert.SerializeObject(boiteAuLettre));
                if (boiteAuLettreCreated.t != null)
                {
                    var pageOk = new MisAJour("La boite aux lettres a été créé.", Color.Green);
                    await PopupNavigation.Instance.PushAsync(pageOk);
                    await Task.Delay(2000);
                    await PopupNavigation.Instance.PopAsync();
                    await PopupNavigation.Instance.PopAsync();
                }
                else
                {
                    string message = "";
                    foreach (KeyValuePair<string, List<string>> attr in boiteAuLettreCreated.Errors)
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