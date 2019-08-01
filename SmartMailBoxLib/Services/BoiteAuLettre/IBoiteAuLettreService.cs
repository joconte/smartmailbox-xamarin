using System;
using SmartMailBoxLib.Models;

namespace SmartMailBoxLib.Services
{
    public interface IBoiteAuLettreService
    {
        GenericObjectWithErrorModel<BoiteAuLettre> PostCreateBoiteAuLettre(BoiteAuLettre boiteAuLettre);

        GenericObjectWithErrorModel<Utilisateur> PutAjoutBoiteToUtilisateur(BoiteAuLettre boiteAuLettre);
    }
}
