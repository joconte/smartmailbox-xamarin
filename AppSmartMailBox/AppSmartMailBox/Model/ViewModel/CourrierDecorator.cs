using System;
using System.Collections.Generic;
using System.Text;
using SmartMailBoxLib.Models;

namespace AppSmartMailBox.Model.ViewModel
{
    public abstract class CourrierDecorator : Courrier
    {
        readonly Courrier _courrier = null;
        protected CourrierDecorator(Courrier courrier)
        {
            this._courrier = courrier;
        }

        public long id => this._courrier.id;

        public new double dateReception => this._courrier.dateReception;

        public string DateReception => Func.Func.JavaTimeStampToDateTime(this._courrier.dateReception).ToString("dddd, dd MMMM yyyy");

        public string HeureMinuteReception => Func.Func.JavaTimeStampToDateTime(this._courrier.dateReception).ToString("HH:mm");

        public string ColorCourrier => !this._courrier.vu ? "#47abe0" : "LightGray";

        public string IconVu => !this._courrier.vu ? "fa-close" : "fa-check";

        public string IconVuColor => !this._courrier.vu ? "Red" : "Green";

        public string FrameCourrierVuIsVisible => !this._courrier.vu ? "True" : "False";
    }
}
