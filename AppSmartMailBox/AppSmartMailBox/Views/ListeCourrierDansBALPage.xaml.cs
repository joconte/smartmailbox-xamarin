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
        private List<CourrierViewModel> courriers;
        private long idBoiteAuLettre;
        public ListeCourrierDansBALPage(int id)
        {
            idBoiteAuLettre = id;
            InitBindings();


            Title = App.utilisateur.boiteAuLettres.Where(e => e.id == id).Select(e => e.description).FirstOrDefault();
        }

        private void InitBindings()
        {
            InitializeComponent();
            List<Courrier> courriersStd = App.utilisateur.boiteAuLettres.Where(e => e.id == idBoiteAuLettre).SelectMany(e => e.courriers).ToList();
            courriers = new List<CourrierViewModel>();
            foreach (var courrier in courriersStd)
            {
                courriers.Add(new CourrierViewModel(courrier));
            }
            MyListViewCourrier.ItemsSource = courriers.OrderByDescending(e => e.dateReception);
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
                App.utilisateur.boiteAuLettres.Where(e => e.id == idBoiteAuLettre).FirstOrDefault().courriers.Where(e => e.id == id).FirstOrDefault().vu = true;
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