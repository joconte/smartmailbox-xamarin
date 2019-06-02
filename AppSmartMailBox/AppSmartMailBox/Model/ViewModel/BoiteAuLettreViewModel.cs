using System;
using System.Collections.Generic;
using System.Text;

namespace AppSmartMailBox.Model.ViewModel
{
    public class BoiteAuLettreViewModel : BoiteAuLettreDecorator
    {
        public BoiteAuLettreViewModel(BoiteAuLettre boiteAuLettre) : base(boiteAuLettre)
        {
        }
        
    }
}
