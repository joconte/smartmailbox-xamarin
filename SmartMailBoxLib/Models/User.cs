﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMailBoxLib.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }

        public string IdProposant { get; set; }

        public DateTime DateDeNaissance { get; set; }

        public User() { }

        public User(string pUsername, string pPassword)
        {
            this.Username = pUsername;
            this.Password = pPassword;
        }
        public User(string pUsername, string pPassword, string pMail, DateTime pDateDeNaissance)
        {
            this.Username = pUsername;
            this.Password = pPassword;
            this.Mail = pMail;
            this.DateDeNaissance = pDateDeNaissance;
        }


    }
}
