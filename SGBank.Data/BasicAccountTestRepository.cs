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
    public class BasicAccountTestRepository : IAccountRepository
    {
        private FileAccountRepository _fileAccountRepository;

        public BasicAccountTestRepository(FileAccountRepository fileAccountRepository)
        {
            _fileAccountRepository = fileAccountRepository;
        }

        public BasicAccountTestRepository()
        {
        }

        private static Account _account = new Account
        {
            Name = "Basic Account",
            Balance = 100M,
            AccountNumber = "33333",
            Type = AccountType.Basic
        };

        public Account LoadAccount(string AccountNumber)
        {
            StoreAccounts(_account);
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

        public void StoreAccounts(Account addAccount)
        {
            _fileAccountRepository.fileAccounts.Add(addAccount);
        }
    }
}
