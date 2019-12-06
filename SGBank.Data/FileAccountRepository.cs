using SGBank.Models;
using SGBank.Data;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        //private FreeAccountTestRepository _freeAccountTestRepository;
        //private BasicAccountTestRepository _basicAccountTestRepository;
        //private PremiumAccountTestRepository _premiumAccountTestRepository;

        public List<Account> fileAccounts = new List<Account>();

        public FileAccountRepository(string mode)
        {
            GetUsers(mode);
        }        

        public void GetUsers(string mode) {            
            var dictionaryOfModes = new Dictionary<string, string>
            {
                ["FreeTest"] = "F",
                ["BasicTest"] = "B",
                ["PremiumTest"] = "P"
            };

            string path = @"C:\Users\cashamerica12345\Documents\TheSoftwareGuildWork\BADGE 2\Milestone4\assignment\SGBank\SGBank.Data\Accounts.txt";
            string[] rows = File.ReadAllLines(path);

            for (int i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');

                if (columns[3] == dictionaryOfModes[mode])
                {
                    Account _account = new Account();
                    _account.AccountNumber = columns[0];
                    _account.Name = columns[1];
                    _account.Balance = Decimal.Parse(columns[2]);
                    if (columns[3] == "F")
                    {
                        _account.Type = AccountType.Free;
                    }
                    else if (columns[3] == "B")
                    {
                        _account.Type = AccountType.Basic;
                    }
                    else if (columns[3] == "P")
                    {
                        _account.Type = AccountType.Premium;
                    }

                    //fileAccounts.Add(_account);
                    StoreAccounts(_account);
                }
            }            
        }
        
        public Account LoadAccount(string AccountNumber)
        {
            return fileAccounts.FirstOrDefault(x => x.AccountNumber == AccountNumber);
        }

        public void SaveAccount(Account account)
        {
            //_account = account;
        }

        public void StoreAccounts(Account addAccount)
        {
            fileAccounts.Add(addAccount);
        }
    }
}
