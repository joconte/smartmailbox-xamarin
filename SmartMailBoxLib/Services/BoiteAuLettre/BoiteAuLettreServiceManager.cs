using System;
using SmartMailBoxLib.Models;

namespace SmartMailBoxLib.Services
{
    public class BoiteAuLettreServiceManager
    {
        public BoiteAuLettreServiceManager()
        {
        }

        public static IBoiteAuLettreService GetBoiteAuLettreService()
        {
            IBoiteAuLettreService boiteAuLettreService;
            if (Constants.IsMocked)
                boiteAuLettreService = new BoiteAuLettreServiceMocked();
            else
                boiteAuLettreService = new BoiteAuLettreServiceApi();

            return boiteAuLettreService;
        }
    }
}
