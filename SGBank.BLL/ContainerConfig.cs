using Autofac;
using SGBank.Data;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SGBank.BLL
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<FileAccountRepository>().As<FileAccountRepository>().WithParameter("mode", mode);

            if (mode == "FreeTest")
                builder.RegisterType<FreeAccountTestRepository>().As<IAccountRepository>();
            else if (mode == "BasicTest")
                builder.RegisterType<BasicAccountTestRepository>().As<IAccountRepository>();
            else if (mode == "PremiumTest")
                builder.RegisterType<PremiumAccountTestRepository>().As<IAccountRepository>();
            else
                throw new Exception("Mode value in app config is not valid");

            builder.RegisterType<AccountManager>().As<AccountManager>();
            builder.RegisterAssemblyTypes(Assembly.Load("SGBank.data"))
                .Where(x => x.Namespace.Contains("Interfaces"))
                .As(x => x.GetInterfaces().FirstOrDefault(i => i.Name == "I" + x.Name));

            return builder.Build();
        }
    }
}
