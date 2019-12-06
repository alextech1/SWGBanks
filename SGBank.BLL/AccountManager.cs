using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Data;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public class AccountManager
    {
        private IAccountRepository _accountRepository;
        private FileAccountRepository _fileAccountRepository;

        public AccountManager(IAccountRepository accountRepository, FileAccountRepository fileAccountRepository) //IAccountRepository accountRepository, FileAccountRepository fileAccountRepository
        {
            _fileAccountRepository = fileAccountRepository;
            _accountRepository = accountRepository;
        }

        /*public AccountManager(FileAccountRepository fileAccountRepository)
        {
            _fileAccountRepository = fileAccountRepository;
        }*/

        public AccountLookupResponse LookupAccount(string accountNumber)
        {
            AccountLookupResponse response = new AccountLookupResponse();

            //response.Account = _accountRepository.LoadAccount(accountNumber);            
            response.Account = _fileAccountRepository.LoadAccount(accountNumber);            

            if(response == null)
            {
                response.Success = false;
                response.Message = $"{accountNumber} is not a valid account.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public AccountDepositResponse Deposit(string accountNumber, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();

            response.Account = _fileAccountRepository.LoadAccount(accountNumber);
            //response.Account = _accountRepository.LoadAccount(accountNumber);

            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"{accountNumber} is not a valid account.";
                return response;
            }
            else
            {
                response.Success = true;
            }

            IDeposit depositRule = DepositRulesFactory.Create(response.Account.Type);
            response = depositRule.Deposit(response.Account, amount);

            if(response.Success)
            {
                _fileAccountRepository.SaveAccount(response.Account);
                //_accountRepository.SaveAccount(response.Account);
            }

            return response;
        }

        public AccountWithdrawResponse Withdraw(string accountNumber, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            response.Account = _fileAccountRepository.LoadAccount(accountNumber);
            //response.Account = _accountRepository.LoadAccount(accountNumber);

            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"{accountNumber} is not valid.";
                return response;
            }
            else
            {
                response.Success = true;
            }

            IWithdraw withdrawRule = WithdrawRulesFactory.Create(response.Account.Type);
            response = withdrawRule.Withdraw(response.Account, amount);

            if(response.Success)
            {
                _fileAccountRepository.SaveAccount(response.Account);
                //_accountRepository.SaveAccount(response.Account);
            }

            return response;
        }
    }
}
