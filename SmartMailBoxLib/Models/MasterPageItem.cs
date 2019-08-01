using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace SmartMailBoxLib.Models
{
    public class MasterPageItem : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string IconColor { get; set; }
        public Type TargetType { get; set; }

        bool _indicateur;

        Color _labelColor;
        public Color LabelColor
        {
            set
            {
                _labelColor = value;
                OnPopertyChanged("LabelColor");
            }
            get => _labelColor;
        }
        public bool Indicateur
        {
            set
            {
                _indicateur = value;
                OnPopertyChanged("Indicateur");
            }
            get => _indicateur;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPopertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
