using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmartMailBoxLib.Models;
using SmartMailBoxLib.REST;

namespace SmartMailBoxLib.Services
{
    public class AccountServiceApi : IAccountService
    {

        public AccountServiceApi()
        {
        }

        //Login api avec token
        public async Task<string> Login(Utilisateur utilisateur)
        {
            string response = PostReponseLogin(Constants.LoginUrl, utilisateur, RestService.Instance._client);
            RestService.Instance._client.DefaultRequestHeaders.Authorization
                     = new AuthenticationHeaderValue("Bearer", response);
            return response;
        }

        public string PostReponseLogin(string url, Utilisateur utilisateur, HttpClient _client)
        {
            string token = null;
            const string contentType = "application/json";

            string jsonstring = JsonConvert.SerializeObject(utilisateur);
            jsonstring = jsonstring ?? "";
            var httpContent = new StringContent(jsonstring, Encoding.UTF8, contentType);
            var result = _client.PostAsync(url, httpContent).Result;
            var jsonResult = result.Content.ReadAsStringAsync().Result;
            token = jsonResult;

            return token;
        }

        public GenericObjectWithErrorModel<string> PostForgotPassword(string pUsername)
        {
            return RestService.Instance.PostReponse<string>(Constants.ForgotPassword, pUsername);
        }

        public GenericObjectWithErrorModel<Utilisateur> PostCreateAccount(Utilisateur _utilisateur)
        {
            return RestService.Instance.PostReponse<Utilisateur>(Constants.RegisterUtilisateur, JsonConvert.SerializeObject(_utilisateur));
        }

        public void Logout()
        {
            RestService.Instance.Logout();
        }

    }
}
