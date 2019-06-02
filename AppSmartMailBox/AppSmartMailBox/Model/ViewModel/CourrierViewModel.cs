using System;
using System.Collections.Generic;
using System.Text;

namespace AppSmartMailBox.Model.ViewModel
{
    public class CourrierViewModel : CourrierDecorator
    {
        public CourrierViewModel(Courrier courrier) : base(courrier)
        {
        }
    }
}
