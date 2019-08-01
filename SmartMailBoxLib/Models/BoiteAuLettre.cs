using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMailBoxLib.Models
{
    public class BoiteAuLettre
    {
        public long id { get; set; }

        public string numeroSerie { get; set; }

        public string token { get; set; }

        public string description { get; set; }

        public List<Courrier> courriers { get; set; }

        public double? lastActivity { get; set; }
    }
}
