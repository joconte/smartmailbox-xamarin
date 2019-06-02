using AppSmartMailBox.Model;
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
    public partial class MasterPageDetail : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public MasterPageDetail()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            Identite.Text = App.utilisateur.lastName!= null ? App.utilisateur.lastName.ToUpper() : "" + " " + App.utilisateur.firstName!= null ? App.utilisateur.firstName: "";

            menuList = new List<MasterPageItem>();

            
            var page1 = new MasterPageItem() { id = 1, Title = "Informations personnelles", Icon = "fa-user", IconColor = "#50a9db", TargetType = typeof(InfosPersonnellesPage) };
            menuList.Add(page1);

            Page pageAccueil = new InfosPersonnellesPage();

            /*if (App.dossierBilanSantes.Any(e => e.EtatDossier == EtatDossier.Termine))
            {
                var page5 = new MasterPageItem() { id = 5, Title = "Anciens dossiers", Icon = "fa-folder-open", IconColor = "#50a9db", TargetType = typeof(ListeDossiersAnterieursCarouselPage) };
                menuList.Add(page5);
                pageAccueil = new ListeDossiersAnterieursCarouselPage();
            }
            */
            
            var page2 = new MasterPageItem() { id = 2, Title = "Boites aux lettres", Icon = "fa-folder-open", IconColor = "#50a9db", TargetType = typeof(ListeBoiteAuLettrePage) };
            menuList.Add(page2);
            pageAccueil = new ListeBoiteAuLettrePage();
            
            //Création des items du menu Android / IOS icons

            var page3 = new MasterPageItem() { id = 3, Title = "Ajout boite aux lettres", Icon = "fa-plus-circle", IconColor = "#50a9db", TargetType = typeof(AjoutBALPage) };
            menuList.Add(page3);
            if(App.utilisateur.role==Utilisateur.Role.Admin)
            {
                var page5 = new MasterPageItem() { id = 5, Title = "Admin : Créer boite aux lettres", Icon = "fa-plus-circle", IconColor = "#50a9db", TargetType = typeof(CreateBALPage) };
                menuList.Add(page5);
            }
            
            var page4 = new MasterPageItem() { id = 4, Title = "Se deconnecter", Icon = "fa-power-off", IconColor = "Gray", TargetType = typeof(MainPage) };
            menuList.Add(page4);
            /*
            //Ajout de chaque item créer au menu.

            
            
            */
            navigationDrawerList.ItemsSource = menuList;
            
            Detail = new NavigationPage(pageAccueil);
            /*
            Detail = new NavigationPage(pageAccueil);
            Detail = new NavigationPage();*/
        }

        private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            foreach (var item in menuList)
            {
                item.LabelColor = Color.Gray;
            }
            MasterPageItem model = e.SelectedItem as MasterPageItem;
            model.Indicateur = true;
            //model.LabelColor = ColorItemMenuSelected(model.id);
        }

        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            var myselecteditem = e.Item as MasterPageItem;
            if (myselecteditem != null)
            {
                var page = new UserAnimationPage();

                await PopupNavigation.Instance.PushAsync(page);
                switch (myselecteditem.id)
                {

                    case 1:
                        Detail = new NavigationPage(new InfosPersonnellesPage());
                        break;
                        
                    case 2:
                        Detail = new NavigationPage(new ListeBoiteAuLettrePage());
                        break;
                        
                    case 3:
                        Detail = new NavigationPage(new AjoutBALPage());
                        break;
                        
                    case 4:
                        // Logique de deconnexion à mettre en place
                        App.Rest = null;
                        App.restService = null;
                        App.utilisateur = null;
                        
                        Detail = new NavigationPage(new MainPage());
                        break;
                        
                    case 5:
                        Detail = new NavigationPage(new CreateBALPage());
                        break;

                }
                await PopupNavigation.Instance.PopAsync();
                //((ListView)sender).SelectedItem = null;
                await Task.Delay(10);
                IsPresented = false;
                myselecteditem.Indicateur = false;

            }
        }
    }
}