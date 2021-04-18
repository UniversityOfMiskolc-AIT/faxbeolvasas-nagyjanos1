using System.Collections.Generic;
using System.Text;

namespace FaxReader.Lib
{
    public class AccountService
    {
        private readonly IAccountFactory _accountFactory;

        public AccountService(IAccountFactory accountFactory)
        {
            _accountFactory = accountFactory;
        }

        public IEnumerable<string> GenerateInDigitFormat(int? startNumber = null, int? accountCnt = null)
        {
            if (startNumber == null) 
            {
                startNumber = 100000000;
            }
            if (accountCnt == null)
            {
                accountCnt = 500;
            }

            var allAccount = new List<string>();
            var accountGenerator = new AccountGenerator(startNumber.Value, accountCnt.Value, true);
            accountGenerator.Generate();
            foreach (var accountStr in accountGenerator.Accounts)
            {
                var account = _accountFactory.Create(accountStr);
                account.Parse();
                allAccount.AddRange(account.ToStringArray());                
            }

            return allAccount;
        }

        public IEnumerable<Account> ParseBankAccounts(string[] digitAccounts)
        {            
            for (var i = 0; i < digitAccounts.Length; i += 3)
            {
                yield return _accountFactory.Create(digitAccounts[i], digitAccounts[i + 1], digitAccounts[i + 2]);
            }
        }

        public IEnumerable<string> ValidateAccounts(IEnumerable<Account> accounts)
        {
            var stringBuilder = new StringBuilder();
            foreach (var account in accounts)
            {
                stringBuilder.Clear();
                account.Parse();

                var multiPlier = 1;
                var sum = 0;                
                foreach (var number in account.Numbers)
                {
                    var value = number.Parse();
                    if (value == null)
                    {
                        stringBuilder.Append('?');
                        account.HasIllegalChar = true;
                    }
                    else
                    {
                        stringBuilder.Append(value);
                        sum += multiPlier * value.Value;
                    }
                    multiPlier++;
                }

                if (account.HasIllegalChar)
                {
                    stringBuilder.Append(" ERR");
                } 
                else if (sum % 11 != 0)
                {
                    stringBuilder.Append(" ILL");
                }

                yield return stringBuilder.ToString();
            }
        }
    }
}
