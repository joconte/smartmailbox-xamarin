using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace AppSmartMailBox.Model
{
    public class MasterPageItem : INotifyPropertyChanged
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string IconColor { get; set; }
        public Type TargetType { get; set; }

        bool indicateur;

        Color labelColor;
        public Color LabelColor
        {
            set
            {
                labelColor = value;
                OnPopertyChanged("LabelColor");
            }
            get
            {
                return labelColor;
            }
        }
        public bool Indicateur
        {
            set
            {
                indicateur = value;
                OnPopertyChanged("Indicateur");
            }
            get
            {
                return indicateur;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPopertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
