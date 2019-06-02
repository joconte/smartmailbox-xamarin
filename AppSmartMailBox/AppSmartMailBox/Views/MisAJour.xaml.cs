using Rg.Plugins.Popup.Pages;
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
    public partial class MisAJour : PopupPage
    {
        private string TextToDisplay;
        private Color ColorPopup;
        public MisAJour(string pTextToDisplay, Color pColorPopup)
        {
            TextToDisplay = pTextToDisplay;
            ColorPopup = pColorPopup;
            InitializeComponent();
            Frame_Popup.BackgroundColor = pColorPopup;
            Label_TextToDisplay.Text = pTextToDisplay;
        }

        private void OnClose(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}