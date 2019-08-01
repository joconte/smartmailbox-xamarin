using System;
using SmartMailBoxLib.Models;
using SmartMailBoxLib.REST;

namespace SmartMailBoxLib.Services
{
    public class CourrierServiceApi : ICourrierService
    {
        public CourrierServiceApi()
        {
        }

        public GenericObjectWithErrorModel<Models.Courrier> PutCourrierVu(int pId)
        {
            return RestService.Instance.PutResponse<Models.Courrier>(String.Format(Constants.UpdateCourrierBybyId, pId), null);
        }
    }
}
