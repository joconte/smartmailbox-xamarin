using AppSmartMailBox.Model;
using AppSmartMailBox.Model.ViewModel;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSmartMailBox.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeBoiteAuLettrePage : ContentPage
    {
        public List<BoiteAuLettreViewModel> BoiteAuLettres;
        public ListeBoiteAuLettrePage()
        {
            BindingContext = new RefreshBoiteAuLettreViewModel(this);
        }

        protected override async void OnAppearing()
        {
            var page = new UserAnimationPage();
            await PopupNavigation.Instance.PushAsync(page);
            InitBinding();
            await PopupNavigation.Instance.PopAsync();
        }

        public void InitBinding()
        {
            InitializeComponent();
            BoiteAuLettres = new List<BoiteAuLettreViewModel>();
            foreach (var boiteAuLettre in App.Utilisateur.boiteAuLettres)
            {
                BoiteAuLettres.Add(new BoiteAuLettreViewModel(boiteAuLettre));
            }
            ObservableCollection<BoiteAuLettre> observableCollection = new ObservableCollection<BoiteAuLettre>(BoiteAuLettres);
            MyListViewBAL.ItemsSource = observableCollection;
        }

        private async void MyListViewBAL_ItemTapped(object sender, EventArgs e)
        {
            Frame dossier = (Frame)sender;
            int id = int.Parse(dossier.ClassId);

            await Navigation.PushAsync(new ListeCourrierDansBALPage(id));
        }

        
    }
}