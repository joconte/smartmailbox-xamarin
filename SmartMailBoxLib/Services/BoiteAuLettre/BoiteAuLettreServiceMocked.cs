using System;
using SmartMailBoxLib.Models;

namespace SmartMailBoxLib.Services
{
    public class BoiteAuLettreServiceMocked : IBoiteAuLettreService
    {
        public BoiteAuLettreServiceMocked()
        {
        }

        public GenericObjectWithErrorModel<BoiteAuLettre> PostCreateBoiteAuLettre(BoiteAuLettre boiteAuLettre)
        {
            GenericObjectWithErrorModel<BoiteAuLettre> genericObjectWithErrorModel = new GenericObjectWithErrorModel<BoiteAuLettre>();
            genericObjectWithErrorModel.t = boiteAuLettre;
            return genericObjectWithErrorModel;
        }

        public GenericObjectWithErrorModel<Utilisateur> PutAjoutBoiteToUtilisateur(BoiteAuLettre boiteAuLettre)
        {
            GenericObjectWithErrorModel<Utilisateur> genericObjectWithErrorModel = new GenericObjectWithErrorModel<Utilisateur>();
            Utilisateur utilisateur = new Utilisateur();
            utilisateur.boiteAuLettres.Add(boiteAuLettre);
            genericObjectWithErrorModel.t = utilisateur;
            return genericObjectWithErrorModel;
        }
    }
}
