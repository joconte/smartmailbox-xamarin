using AppSmartMailBox.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using SmartMailBoxLib.Models;
using SmartMailBoxLib.REST;
using SmartMailBoxLib.Services;

namespace AppSmartMailBox.Model.ViewModel
{
    public class RefreshBoiteAuLettreViewModel : INotifyPropertyChanged
    {
        private IUtilisateurService utilisateurService;
        public ObservableCollection<string> Items { get; set; }
        readonly ListeBoiteAuLettrePage _page;
        public RefreshBoiteAuLettreViewModel(ListeBoiteAuLettrePage page)
        {
            this._page = page;
            Items = new ObservableCollection<string>();
            utilisateurService = UtilisateurServiceManager.GetUtilisateurService();
        }

        bool _canRefresh = true;

        public bool CanRefresh
        {
            get => _canRefresh;
            set
            {
                if (_canRefresh == value)
                    return;

                _canRefresh = value;
                OnPropertyChanged("CanRefresh");
            }
        }


        bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy == value)
                    return;

                _isBusy = value;
                OnPropertyChanged("IsBusy");
            }
        }

        ICommand _refreshCommand;

        public ICommand RefreshCommand
        {
            get { return _refreshCommand ?? (_refreshCommand = new Command(async () => await ExecuteRefreshCommand())); }
        }

        async Task ExecuteRefreshCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            Items.Clear();

            GenericObjectWithErrorModel<Utilisateur> utilisateurWithError = utilisateurService.GetUtilisateurConnectedWithErrorModel();
            if (utilisateurWithError.t == null)
            {
                throw new Exception("Le proposant n'a pas été trouvé.");
            }
            else
            {
                App.Utilisateur = utilisateurWithError.t;
            }

            IsBusy = false;

            this.CanRefresh = false;
            _page.InitBinding();
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
