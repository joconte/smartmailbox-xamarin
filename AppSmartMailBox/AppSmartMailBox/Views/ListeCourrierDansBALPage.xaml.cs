using AppSmartMailBox.Model;
using AppSmartMailBox.Model.ViewModel;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSmartMailBox.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeCourrierDansBALPage : ContentPage
    {
        private List<CourrierViewModel> _courriers;
        private readonly long _idBoiteAuLettre;
        public ListeCourrierDansBALPage(int id)
        {
            _idBoiteAuLettre = id;
            InitBindings();


            Title = App.Utilisateur.boiteAuLettres.Where(e => e.id == id).Select(e => e.description).FirstOrDefault();
        }

        private void InitBindings()
        {
            InitializeComponent();
            List<Courrier> courriersStd = App.Utilisateur.boiteAuLettres.Where(e => e.id == _idBoiteAuLettre).SelectMany(e => e.courriers).ToList();
            _courriers = new List<CourrierViewModel>();
            foreach (var courrier in courriersStd)
            {
                _courriers.Add(new CourrierViewModel(courrier));
            }
            MyListViewCourrier.ItemsSource = _courriers.OrderByDescending(e => e.dateReception);
        }

        private async void CourrierVu(object sender, EventArgs ev)
        {
            var page = new UserAnimationPage();

            await PopupNavigation.Instance.PushAsync(page);

            Frame courrier = (Frame)sender;
            int id = int.Parse(courrier.ClassId);

            var courrierUpdated = App.Rest.PutResponse<Courrier>(String.Format(Constants.UpdateCourrierBybyId, id), null);

            if(courrierUpdated.t!=null)
            {
                App.Utilisateur.boiteAuLettres.FirstOrDefault(e => e.id == _idBoiteAuLettre).courriers.FirstOrDefault(e => e.id == id).vu = true;
                InitBindings();
            }
            await PopupNavigation.Instance.PopAsync();
        }

        private void MyListViewCourrier_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // don't do anything if we just de-selected the row.
            if (e.Item == null) return;

            // Optionally pause a bit to allow the preselect hint.
            Task.Delay(500);

            // Deselect the item.
            if (sender is ListView lv) lv.SelectedItem = null;

        }
    }
}