using System;
using Newtonsoft.Json;
using SmartMailBoxLib.Models;
using SmartMailBoxLib.REST;

namespace SmartMailBoxLib.Services
{
    public class BoiteAuLettreServiceApi : IBoiteAuLettreService
    {
        public BoiteAuLettreServiceApi()
        {
        }

        public GenericObjectWithErrorModel<BoiteAuLettre> PostCreateBoiteAuLettre(BoiteAuLettre boiteAuLettre)
        {
            return RestService.Instance.PostReponse<BoiteAuLettre>(Constants.CreateBAL, JsonConvert.SerializeObject(boiteAuLettre));
        }

        public GenericObjectWithErrorModel<Utilisateur> PutAjoutBoiteToUtilisateur(BoiteAuLettre boiteAuLettre)
        {
            return RestService.Instance.PostReponse<Utilisateur>(Constants.AddBalToCurrentUser, JsonConvert.SerializeObject(boiteAuLettre));
        }
    }
}
