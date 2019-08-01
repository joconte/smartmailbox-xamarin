using System;
using Newtonsoft.Json;
using SmartMailBoxLib.Models;
using SmartMailBoxLib.REST;
namespace SmartMailBoxLib.Services
{
    public class UtilisateurServiceApi : IUtilisateurService
    {
        public UtilisateurServiceApi()
        {
        }

        public GenericObjectWithErrorModel<Utilisateur> GetUtilisateurConnectedWithErrorModel()
        {
            return RestService.Instance.GetResponse<GenericObjectWithErrorModel<Utilisateur>>(Constants.UtilisateurConnected);
        }

        public GenericObjectWithErrorModel<Utilisateur> PutInformationsPersonnelles(Utilisateur utilisateurUpdated)
        {
            return RestService.Instance.PutResponse<Utilisateur>(Constants.UpdateUser, JsonConvert.SerializeObject(utilisateurUpdated));
        }
    }
}
