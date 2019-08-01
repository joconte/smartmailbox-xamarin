using System;
using System.Collections.Generic;
using System.Text;
using SmartMailBoxLib.Models;

namespace AppSmartMailBox.Model.ViewModel
{
    public class CourrierViewModel : CourrierDecorator
    {
        public CourrierViewModel(Courrier courrier) : base(courrier)
        {
        }
    }
}
