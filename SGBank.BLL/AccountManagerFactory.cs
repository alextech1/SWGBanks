using Autofac;
using SGBank.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public static class AccountManagerFactory
    {
        public static AccountManager Create()
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }

            return container.Resolve<AccountManager>();

            /*
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
            var fileAccount = new FileAccountRepository(mode);

            switch (mode)
            {              
                case "FreeTest":
                    return new AccountManager(fileAccount, new FreeAccountTestRepository());                    
                case "BasicTest":
                    return new AccountManager(fileAccount, new BasicAccountTestRepository());
                case "PremiumTest":
                    return new AccountManager(fileAccount, new PremiumAccountTestRepository(fileAccount));

                default:
                    throw new Exception("Mode value in app config is not valid");
            }*/
        }
    }
}
