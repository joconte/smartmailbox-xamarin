using System;
using SmartMailBoxLib.Models;

namespace SmartMailBoxLib.Services
{
    public class CourrierServiceManager
    {
        public CourrierServiceManager()
        {
        }

        public static ICourrierService GetCourrierService()
        {
            ICourrierService courrierService;
            if (Constants.IsMocked)
                courrierService = new CourrierServiceMocked();
            else
                courrierService = new CourrierServiceApi();

            return courrierService;
        }
    }
}
