using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SmartMailBoxLib.Models
{
    public class Constants
    {
        public static bool IsMocked { get; set; }
        public static readonly Color BackgroundColor = Color.FromArgb(255, 255, 255);
        public static readonly Color MainTextColor = Color.Black;
        public static readonly int LoginIconHeight = 120;

        private static readonly string RouteBase = "https://smartmailbox-epsi.herokuapp.com";
        //private static string RouteBase = "http://192.168.1.17:8080";

        #region url api
        //login connexion
        public static readonly string LoginUrl = "/user/login";
        public static readonly string BaseAdresse = RouteBase ;
        public static readonly string UtilisateurConnected = "secure/user/me";
        public static readonly string UtilisateurById = "user/{0}";
        public static readonly string UpdateCourrierBybyId = "secure/courrier/{0}";
        public static readonly string RegisterUtilisateur = "user";
        public static readonly string ForgotPassword = "user/forgotPassword";
        public static readonly string UpdateUser = "secure/user";
        public static readonly string AddBalToCurrentUser = "secure/user/addBAL";
        public static readonly string CreateBAL = "secure/BAL";
        #endregion url api
    }
}
