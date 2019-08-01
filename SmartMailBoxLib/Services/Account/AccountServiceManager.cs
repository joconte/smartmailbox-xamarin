using System;
using SmartMailBoxLib.Models;

namespace SmartMailBoxLib.Services
{
    public class AccountServiceManager
    {
        public AccountServiceManager()
        {
        }

        public static IAccountService GetAccountService()
        {
            IAccountService accountService;
            if (Constants.IsMocked)
                accountService = new AccountServiceMocked();
            else
                accountService = new AccountServiceApi();

            return accountService;
        }
    }
}
