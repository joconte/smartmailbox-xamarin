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
        public List<MasterPageItem> MenuList { get; set; }
        public MasterPageDetail()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            Identite.Text = App.Utilisateur.lastName.ToUpper() + " " + App.Utilisateur.firstName;

            MenuList = new List<MasterPageItem>();

            
            var page1 = new MasterPageItem() { Id = 1, Title = "Informations personnelles", Icon = "fa-user", IconColor = "#50a9db", TargetType = typeof(InfosPersonnellesPage) };
            MenuList.Add(page1);

            var page2 = new MasterPageItem() { Id = 2, Title = "Boites aux lettres", Icon = "fa-folder-open", IconColor = "#50a9db", TargetType = typeof(ListeBoiteAuLettrePage) };
            MenuList.Add(page2);
            Page pageAccueil = new ListeBoiteAuLettrePage();

            var page3 = new MasterPageItem() { Id = 3, Title = "Ajout boite aux lettres", Icon = "fa-plus-circle", IconColor = "#50a9db", TargetType = typeof(AjoutBALPage) };
            MenuList.Add(page3);
            if(App.Utilisateur.role==Utilisateur.Role.Admin)
            {
                var page5 = new MasterPageItem() { Id = 5, Title = "Admin : Créer boite aux lettres", Icon = "fa-plus-circle", IconColor = "#50a9db", TargetType = typeof(CreateBALPage) };
                MenuList.Add(page5);
            }
            
            var page4 = new MasterPageItem() { Id = 4, Title = "Se deconnecter", Icon = "fa-power-off", IconColor = "Gray", TargetType = typeof(MainPage) };
            MenuList.Add(page4);
            
            navigationDrawerList.ItemsSource = MenuList;
            
            Detail = new NavigationPage(pageAccueil);
           
        }

        private void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            foreach (var item in MenuList)
            {
                item.LabelColor = Color.Gray;
            }
            MasterPageItem model = e.SelectedItem as MasterPageItem;
            model.Indicateur = true;
        }

        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            var myselecteditem = e.Item as MasterPageItem;
            if (myselecteditem != null)
            {
                var page = new UserAnimationPage();

                await PopupNavigation.Instance.PushAsync(page);
                switch (myselecteditem.Id)
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
                        App.RestService = null;
                        App.Utilisateur = null;
                        
                        Detail = new NavigationPage(new MainPage());
                        break;
                        
                    case 5:
                        Detail = new NavigationPage(new CreateBALPage());
                        break;

                }
                await PopupNavigation.Instance.PopAsync();
                await Task.Delay(10);
                IsPresented = false;
                myselecteditem.Indicateur = false;

            }
        }
    }
}