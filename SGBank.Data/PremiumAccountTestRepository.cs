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
        private FileAccountRepository _fileAccountRepository;
        private Account _account;

        public PremiumAccountTestRepository(FileAccountRepository fileAccountRepository)
        {
            _fileAccountRepository = fileAccountRepository;

            _account = new Account
            {
                Name = "Premium Account",
                Balance = 100M,
                AccountNumber = "44444",
                Type = AccountType.Premium
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
                _fileAccountRepository.fileAccounts.Add(account);
                string path = @"C:\testfolder\accounts.txt";
                string[] line = new string[_fileAccountRepository.fileAccounts.Count + 1];
                line[0] = "AccountNumber,Name,Balance,Type";                

                int i = 1;
                foreach (var a in _fileAccountRepository.fileAccounts)
                {
                    line[i] = a.AccountNumber + "," + a.Name + "," + a.Balance + "," + a.Type.ToString().Substring(0, 1);
                    i++;
                }
                
                File.WriteAllLines(path, line);
            }
            else
            {
                _account = account;
            }
        } 
    }
}
