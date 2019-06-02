using System;
using System.Collections.Generic;
using System.Text;

namespace AppSmartMailBox.Model
{
    public class Utilisateur
    {
        public enum Role
        {
            Client,
            Admin
        }

        public long userId { get; set; }

        public String firstName { get; set; }
        public String lastName { get; set; }

        public String email { get; set; }

        public String password { get; set; }

        public byte[] salt { get; set; }

        public Role role { get; set; }


        public List<BoiteAuLettre> boiteAuLettres { get; set; }
    }
}
