using System;
using SmartMailBoxLib.Models;

namespace SmartMailBoxLib.Services
{
    public interface ICourrierService
    {
        GenericObjectWithErrorModel<Models.Courrier> PutCourrierVu(int pId);
    }
}
