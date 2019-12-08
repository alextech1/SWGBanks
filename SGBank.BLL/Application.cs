using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public class Application : IApplication
    {
        IAccountRepository _accountRepository;

        public Application(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void Run()
        {
            
        }
    }
}
