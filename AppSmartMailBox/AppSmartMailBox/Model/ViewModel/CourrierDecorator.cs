using System;
using System.Collections.Generic;
using System.Text;

namespace AppSmartMailBox.Model.ViewModel
{
    public abstract class CourrierDecorator : Courrier
    {
        Courrier Courrier = null;
        protected CourrierDecorator(Courrier courrier)
        {
            this.Courrier = courrier;
        }

        public long id
        {
            get
            {
                return this.Courrier.id;
            }
        }

        
        public new double dateReception
        {
            get
            {
                return this.Courrier.dateReception;
            }
        }

        public string DateReception
        {
            get
            {
                return Func.Func.JavaTimeStampToDateTime(this.Courrier.dateReception).ToString("dddd, dd MMMM yyyy");
            }
        }

        public string HeureMinuteReception
        {
            get
            {
                return Func.Func.JavaTimeStampToDateTime(this.Courrier.dateReception).ToString("HH:mm");
            }
        }

        public string ColorCourrier
        {
            get
            {
                return this.Courrier.vu == false ? "#47abe0" : "LightGray";
            }
        }

        public string IconVu
        {
            get
            {
                return this.Courrier.vu == false ? "fa-close" : "fa-check";
            }
        }

        public string IconVuColor
        {
            get
            {
                return this.Courrier.vu == false ? "Red" : "Green";
            }
        }

        public string FrameCourrierVuIsVisible
        {
            get
            {
                return this.Courrier.vu == false ? "True" : "False";
            }
        }
    }
}
