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
        private Account _account;

        public BasicAccountTestRepository(FileAccountRepository fileAccountRepository)
        {
            _fileAccountRepository = fileAccountRepository;

            _account = new Account
            {
                Name = "Basic Account",
                Balance = 100M,
                AccountNumber = "33333",
                Type = AccountType.Basic
            };

            SaveAccount(_account);
        }

        public Account LoadAccount(string AccountNumber)
        {
            return _fileAccountRepository.fileAccounts.FirstOrDefault(x => x.AccountNumber == AccountNumber);
        }

        public void SaveAccount(Account account)
        {
            if (!_fileAccountRepository.fileAccounts.Any(x => x.AccountNumber == account.AccountNumber))
            {
                _fileAccountRepository.SaveAccount(account);
            }
            else
            {
                _account = account;
                _fileAccountRepository.SaveAccount(account);
            }
        }
    }
}
