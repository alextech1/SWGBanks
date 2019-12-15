using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models
{
    public class Account
    {
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public AccountType Type { get; set; }

        public Account() { }

        public Account(string account)
        {
            List<string> accountInfo = account.Split(',').ToList();
            string accountNum = accountInfo.FirstOrDefault();
            AccountNumber = accountNum;
            Type = (AccountType)Enum.Parse(typeof(AccountType), accountInfo.Skip(1).FirstOrDefault().Split(' ').First());

            decimal.TryParse(accountInfo.Skip(2).FirstOrDefault(), out decimal balance);
            Balance = balance;
            Name = accountInfo.Skip(3).FirstOrDefault();
        }

        public override string ToString()
        {
            string strType = "";
            if (Type == AccountType.Free)
                strType = "F";
            else if (Type == AccountType.Basic)
                strType = "B";
            else if (Type == AccountType.Premium)
                strType = "P";

            return $"{AccountNumber},{Name},{Balance},{strType}";
        }
    }
}
