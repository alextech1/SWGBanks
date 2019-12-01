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

        /*public override string ToString() //Display at index
        {
            return string.Format
                ("DVD [Name: {0}; AccountNumber: {1}; Balance: {2}; Type: {3};]",
                Name, AccountNumber, Balance, Type);
        }*/

        /*public bool Equals(Account obj)
        {
            return obj != null &&
                Name == obj.Name &&
                AccountNumber == obj.AccountNumber &&
                Balance == obj.Balance &&
                Type == obj.Type;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Account);
        }

        public override int GetHashCode()
        {
            var hashCode = 649529027;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AccountNumber);
            hashCode = hashCode * -1521134295 + Balance.GetHashCode();
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            return hashCode;
        }*/
    }
}
