using System;
using SmartMailBoxLib.Models;

namespace SmartMailBoxLib.Services
{
    public class CourrierServiceMocked : ICourrierService
    {
        public CourrierServiceMocked()
        {
        }

        public GenericObjectWithErrorModel<Models.Courrier> PutCourrierVu(int pId)
        {
            GenericObjectWithErrorModel<Models.Courrier> genericObjectWithErrorModel = new GenericObjectWithErrorModel<Models.Courrier>();
            genericObjectWithErrorModel.t = new Models.Courrier();
            return genericObjectWithErrorModel;
        }
    }
}
