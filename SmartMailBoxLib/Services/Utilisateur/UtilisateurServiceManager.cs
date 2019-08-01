using System;
using SmartMailBoxLib.Models;

namespace SmartMailBoxLib.Services
{
    public class UtilisateurServiceManager
    {
        public UtilisateurServiceManager()
        {
        }

        public static IUtilisateurService GetUtilisateurService()
        {
            IUtilisateurService utilisateurService;
            if (Constants.IsMocked)
                utilisateurService = new UtilisateurServiceMocked();
            else
                utilisateurService = new UtilisateurServiceApi();

            return utilisateurService;
        }
    }
}
