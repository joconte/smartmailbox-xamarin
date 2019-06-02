using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppSmartMailBox.Func;

namespace AppSmartMailBox.Model.ViewModel
{
    public abstract class BoiteAuLettreDecorator : BoiteAuLettre
    {
        BoiteAuLettre BoiteAuLettre = null;

        protected BoiteAuLettreDecorator(BoiteAuLettre boiteAuLettre)
        {
            this.BoiteAuLettre = boiteAuLettre;
        }

        public string NbCourrier
        {
            get
            {
                return this.BoiteAuLettre.courriers.Count > 1 ? this.BoiteAuLettre.courriers.Count.ToString() + " courriers" : this.BoiteAuLettre.courriers.Count == 1 ? this.BoiteAuLettre.courriers.Count.ToString() + " courrier" : "Aucun courrier";
            }
        }

        public string NbCourrierNonVu
        {
            get
            {
                List<Courrier> courriersNonVu = this.BoiteAuLettre.courriers.Where(e => e.vu == false).ToList();
                return courriersNonVu.Count > 1 ? courriersNonVu.Count.ToString() + " nouveaux courriers": courriersNonVu.Count == 1 ? courriersNonVu.Count.ToString() + " nouveau courrier" :"Aucun nouveau courrier";
            }
        }

        public long id
        {
            get
            {
                return this.BoiteAuLettre.id;
            }
        }

        public string description
        {
            get
            {
                return this.BoiteAuLettre.description;
            }
        }

        public string DateDerniereActivite
        {
            get
            {
                return this.BoiteAuLettre.lastActivity.HasValue ? Func.Func.JavaTimeStampToDateTime(this.BoiteAuLettre.lastActivity.Value).ToString("dddd, dd MMMM yyyy") : "Aucune";
                //return this.BoiteAuLettre.lastActivity.HasValue ? this.BoiteAuLettre.lastActivity.Value.ToString() : "Aucune";
            }
        }

        public string ColorBoiteAuLettre
        {
            get
            {
                List<Courrier> courriersNonVu = this.BoiteAuLettre.courriers.Where(e => e.vu == false).ToList();
                return courriersNonVu.Count > 0 ? "#47abe0" : "LightGray";
            }
        }
    }

    

}
