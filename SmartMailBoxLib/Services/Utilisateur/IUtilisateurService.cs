using System;
using SmartMailBoxLib.Models;

namespace SmartMailBoxLib.Services
{
    public interface IUtilisateurService
    {
        GenericObjectWithErrorModel<Utilisateur> GetUtilisateurConnectedWithErrorModel();

        GenericObjectWithErrorModel<Utilisateur> PutInformationsPersonnelles(Utilisateur utilisateurUpdated);
    }
}
