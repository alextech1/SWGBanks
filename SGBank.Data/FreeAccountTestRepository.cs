using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using System.IO;

namespace SGBank.Data
{
    public class FreeAccountTestRepository : IAccountRepository
    {
        private FileAccountRepository _fileAccountRepository;

        public FreeAccountTestRepository(FileAccountRepository fileAccountRepository)
        {
            _fileAccountRepository = fileAccountRepository;
        }

        public FreeAccountTestRepository()
        {

        }

        private static Account _account = new Account
        {
            Name = "Free Account",
            Balance = 100.00M,
            AccountNumber = "12345",
            Type = AccountType.Free
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
