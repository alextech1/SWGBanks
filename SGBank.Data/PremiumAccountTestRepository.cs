using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class PremiumAccountTestRepository : IAccountRepository
    {
        private static Account _account = new Account
        {
            Name = "Premium Account",
            Balance = 100M,
            AccountNumber = "44444",
            Type = AccountType.Premium
        };

        public Account LoadAccount(string AccountNumber)
        {
            if (_account.AccountNumber == AccountNumber)
            {
                return _account;
            }

            return null;
        }

        public void SaveAccount(Account account)
        {
            _account = account;
        }
    }
}
