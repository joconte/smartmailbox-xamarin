using System;
using SmartMailBoxLib.Models;
using Newtonsoft.Json;

namespace SmartMailBoxLib.Services
{
    public class UtilisateurServiceMocked : IUtilisateurService
    {
        public UtilisateurServiceMocked()
        {
        }

        public GenericObjectWithErrorModel<Utilisateur> GetUtilisateurConnectedWithErrorModel()
        {
            GenericObjectWithErrorModel<Utilisateur> genericObjectWithErrorModel = new GenericObjectWithErrorModel<Utilisateur>();
            var jsonMocked = "{ \"t\": { \"userId\": 1, \"firstName\": \"Jonathan\", \"lastName\": \"CONTE\", \"email\": \"admin@contejonathan.net\", \"created\": 1559434970449, \"role\": \"Admin\", \"boiteAuLettres\": [ { \"numeroSerie\": \"123456789\", \"description\": null, \"lastActivity\": 1559435308559, \"courriers\": [ { \"vu\": true, \"dateReception\": 1559435304281, \"id\": 6 }, { \"vu\": true, \"dateReception\": 1559435308559, \"id\": 7 } ], \"id\": 4 }, { \"numeroSerie\": \"BAL01\", \"description\": \"bal test\", \"lastActivity\": null, \"courriers\": [], \"id\": 30 }, { \"numeroSerie\": \"vega\", \"description\": \"Missile\", \"lastActivity\": null, \"courriers\": [], \"id\": 51 }, { \"numeroSerie\": \"1234\", \"description\": \"La voisine\", \"lastActivity\": 1560276468344, \"courriers\": [ { \"vu\": true, \"dateReception\": 1560275729556, \"id\": 63 }, { \"vu\": true, \"dateReception\": 1559590445126, \"id\": 62 }, { \"vu\": true, \"dateReception\": 1559588871447, \"id\": 61 }, { \"vu\": true, \"dateReception\": 1559575173234, \"id\": 60 }, { \"vu\": false, \"dateReception\": 1560275802575, \"id\": 64 }, { \"vu\": true, \"dateReception\": 1560276468344, \"id\": 65 } ], \"id\": 59 }, { \"numeroSerie\": \"123456\", \"description\": \"maison\", \"lastActivity\": 1560449420564, \"courriers\": [ { \"vu\": true, \"dateReception\": 1559446024009, \"id\": 20 }, { \"vu\": true, \"dateReception\": 1559446023844, \"id\": 19 }, { \"vu\": true, \"dateReception\": 1559446023672, \"id\": 18 }, { \"vu\": true, \"dateReception\": 1559446023499, \"id\": 17 }, { \"vu\": true, \"dateReception\": 1559446023337, \"id\": 16 }, { \"vu\": true, \"dateReception\": 1559446023163, \"id\": 15 }, { \"vu\": true, \"dateReception\": 1559446013549, \"id\": 10 }, { \"vu\": true, \"dateReception\": 1559446021038, \"id\": 11 }, { \"vu\": true, \"dateReception\": 1559446021929, \"id\": 12 }, { \"vu\": true, \"dateReception\": 1559446022420, \"id\": 13 }, { \"vu\": true, \"dateReception\": 1559446022870, \"id\": 14 }, { \"vu\": true, \"dateReception\": 1559448452349, \"id\": 21 }, { \"vu\": true, \"dateReception\": 1559550660949, \"id\": 48 }, { \"vu\": true, \"dateReception\": 1559550726780, \"id\": 49 }, { \"vu\": true, \"dateReception\": 1559552787391, \"id\": 50 }, { \"vu\": true, \"dateReception\": 1559553629162, \"id\": 53 }, { \"vu\": true, \"dateReception\": 1559553657066, \"id\": 54 }, { \"vu\": true, \"dateReception\": 1560447736854, \"id\": 66 }, { \"vu\": true, \"dateReception\": 1560447949469, \"id\": 67 }, { \"vu\": true, \"dateReception\": 1560449420564, \"id\": 68 } ], \"id\": 2 }, { \"numeroSerie\": \"yannick\", \"description\": \"test demo\", \"lastActivity\": null, \"courriers\": [], \"id\": 69 }, { \"numeroSerie\": \"eva\", \"description\": \"test Eva \", \"lastActivity\": null, \"courriers\": [], \"id\": 70 } ], \"enabled\": true }, \"errors\": null }";
            return JsonConvert.DeserializeObject<GenericObjectWithErrorModel<Utilisateur>>(jsonMocked);
        }

        public GenericObjectWithErrorModel<Utilisateur> PutInformationsPersonnelles(Utilisateur utilisateurUpdated)
        {
            GenericObjectWithErrorModel<Utilisateur> genericObjectWithErrorModel = new GenericObjectWithErrorModel<Utilisateur>();
            genericObjectWithErrorModel.t = utilisateurUpdated;
            return genericObjectWithErrorModel;
        }
    }
}
