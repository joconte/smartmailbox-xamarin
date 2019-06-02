using AppSmartMailBox.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppSmartMailBox.Model.ViewModel
{
    public class RefreshBoiteAuLettreViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Items { get; set; }
        ListeBoiteAuLettrePage page;
        public RefreshBoiteAuLettreViewModel(ListeBoiteAuLettrePage page)
        {
            this.page = page;
            Items = new ObservableCollection<string>();
        }

        bool canRefresh = true;

        public bool CanRefresh
        {
            get { return canRefresh; }
            set
            {
                if (canRefresh == value)
                    return;

                canRefresh = value;
                OnPropertyChanged("CanRefresh");
            }
        }


        bool isBusy;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy == value)
                    return;

                isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        ICommand refreshCommand;

        public ICommand RefreshCommand
        {
            get { return refreshCommand ?? (refreshCommand = new Command(async () => await ExecuteRefreshCommand())); }
        }

        async Task ExecuteRefreshCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            Items.Clear();

            GenericObjectWithErrorModel<Utilisateur> utilisateurWithError = App.Rest.GetResponse<GenericObjectWithErrorModel<Utilisateur>>(Constants.UtilisateurConnected);
            if (utilisateurWithError.t == null)
            {
                throw new Exception("Le proposant n'a pas été trouvé.");
            }
            else
            {
                App.utilisateur = utilisateurWithError.t;
            }

            IsBusy = false;

            //page.DisplayAlert("Refreshed", "You just refreshed the page! Nice job! Pull to refresh is now disabled", "OK");
            this.CanRefresh = false;
            page.InitBinding();
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
