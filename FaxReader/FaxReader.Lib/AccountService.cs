using System.Collections.Generic;
using System.Text;

namespace FaxReader.Lib
{
    /// <summary>
    /// Számla
    /// </summary>
    public class AccountService
    {
        private readonly IAccountFactory _accountFactory;

        public AccountService(IAccountFactory accountFactory)
        {
            _accountFactory = accountFactory;
        }

        /// <summary>
        /// Digit formátumban legenerálja a számlákat a megadott paraméterek alapján.
        /// </summary>
        /// <param name="startNumber">Kezdő érték</param>
        /// <param name="accountCnt">Generálandó számlák száma</param>
        /// <returns>Digit formátumban a számlák sorai</returns>
        public IEnumerable<string> GenerateInDigitFormat(int? startNumber = 100000000, int? accountCnt = 500)
        {
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

        /// <summary>
        /// Digit formátumú nyerssorokat parsolja át, és számal objektumokat hoz létre.
        /// </summary>
        /// <param name="digitAccounts">Digit formátumú nyrs számla sorok.</param>
        /// <returns>A létrehozott számla objektumok.</returns>
        public IEnumerable<Account> ParseBankAccounts(string[] digitAccounts)
        {            
            for (var i = 0; i < digitAccounts.Length; i += 3)
            {
                yield return _accountFactory.Create(digitAccounts[i], digitAccounts[i + 1], digitAccounts[i + 2]);
            }
        }

        /// <summary>
        /// A létrehozott számla objektumokat validálja, a végeredménynek megfelelően 
        /// - ERR jelzi a számla után, a checksum értéke nem megfelelő,
        /// - ILL jelzi, ha nem felismerhető számot tartalmazott.
        /// </summary>
        /// <param name="accounts">Számla objektumok.</param>
        /// <returns>A levalidált számlaszámok a megfelelő validációs jelzésekkel.</returns>
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
