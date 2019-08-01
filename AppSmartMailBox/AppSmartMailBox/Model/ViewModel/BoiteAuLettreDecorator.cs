using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppSmartMailBox.Func;
using SmartMailBoxLib.Models;

namespace AppSmartMailBox.Model.ViewModel
{
    public abstract class BoiteAuLettreDecorator : BoiteAuLettre
    {
        readonly BoiteAuLettre _boiteAuLettre = null;

        protected BoiteAuLettreDecorator(BoiteAuLettre boiteAuLettre)
        {
            this._boiteAuLettre = boiteAuLettre;
        }

        public string NbCourrier => this._boiteAuLettre.courriers.Count > 1 ? this._boiteAuLettre.courriers.Count.ToString() + " courriers" : this._boiteAuLettre.courriers.Count == 1 ? this._boiteAuLettre.courriers.Count.ToString() + " courrier" : "Aucun courrier";

        public string NbCourrierNonVu
        {
            get
            {
                List<Courrier> courriersNonVu = this._boiteAuLettre.courriers.Where(e => !e.vu).ToList();
                return courriersNonVu.Count > 1 ? courriersNonVu.Count.ToString() + " nouveaux courriers": courriersNonVu.Count == 1 ? courriersNonVu.Count.ToString() + " nouveau courrier" :"Aucun nouveau courrier";
            }
        }

        public long id => this._boiteAuLettre.id;

        public string description => this._boiteAuLettre.description;

        public string DateDerniereActivite => this._boiteAuLettre.lastActivity.HasValue ? Func.Func.JavaTimeStampToDateTime(this._boiteAuLettre.lastActivity.Value).ToString("dddd, dd MMMM yyyy") : "Aucune";

        public string ColorBoiteAuLettre
        {
            get
            {
                List<Courrier> courriersNonVu = this._boiteAuLettre.courriers.Where(e => !e.vu).ToList();
                return courriersNonVu.Count > 0 ? "#47abe0" : "LightGray";
            }
        }
    }

    

}
