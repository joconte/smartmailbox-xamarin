using System;
using System.Net.Http;
using System.Threading.Tasks;
using SmartMailBoxLib.Models;

namespace SmartMailBoxLib.Services
{
    public interface IAccountService
    {
        Task<string> Login(Utilisateur utilisateur);

        GenericObjectWithErrorModel<string> PostForgotPassword(string pUsername);

        GenericObjectWithErrorModel<Utilisateur> PostCreateAccount(Utilisateur _utilisateur);

        void Logout();
    }
}
