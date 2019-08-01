using System;
using System.Collections.Generic;
using System.Text;
using SmartMailBoxLib.Models;

namespace AppSmartMailBox.Model.ViewModel
{
    public class BoiteAuLettreViewModel : BoiteAuLettreDecorator
    {
        public BoiteAuLettreViewModel(BoiteAuLettre boiteAuLettre) : base(boiteAuLettre)
        {
        }
        
    }
}
