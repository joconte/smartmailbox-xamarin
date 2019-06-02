using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AppSmartMailBox.Model
{
    public class Constants
    {
        public static bool IsDev = true;
        public static Color BackgroundColor = Color.FromArgb(255, 255, 255);
        public static Color MainTextColor = Color.Black;
        public static int LoginIconHeight = 120;

        private static string RouteBase = "https://smartmailbox-epsi.herokuapp.com";
        //private static string RouteBase = "http://192.168.1.17:8080";

        #region url api
        //login connexion
        public static string LoginUrl = "/user/login";
        public static string BaseAdresse = RouteBase ;
        public static string UtilisateurConnected = "secure/user/me";
        public static string UtilisateurById = "user/{0}";
        public static string UpdateCourrierBybyId = "secure/courrier/{0}";
        public static string RegisterUtilisateur = "user";
        public static string ForgotPassword = "user/forgotPassword";
        public static string UpdateUser = "secure/user";
        public static string AddBalToCurrentUser = "secure/user/addBAL";
        public static string CreateBAL = "secure/BAL";
        #endregion url api
    }
}
