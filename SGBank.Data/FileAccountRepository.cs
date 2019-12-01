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
    public class FileAccountRepository : IAccountRepository
    {
        public List<Account> accounts = new List<Account>();
        //Account newaccount { get; set; }

        public void GetUsers() {
            string path = @"C:\Users\cashamerica12345\Documents\TheSoftwareGuildWork\BADGE 2\Milestone4\assignment\SGBank\SGBank.Data\Accounts.txt";
            string[] rows = File.ReadAllLines(path);            

            for (int i = 1; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');

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

                accounts.Add(_account);
                //newaccount = _account;
            }
        }
        
        public Account LoadAccount(string AccountNumber)
        {
            return accounts.FirstOrDefault(x => x.AccountNumber == AccountNumber);
        }

        public void SaveAccount(Account account)
        {
            //newaccount = account;
        }        
    }
}
