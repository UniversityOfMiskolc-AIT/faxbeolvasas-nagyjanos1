using System;

namespace FaxReader.Lib
{
    public class AccountFactory : IAccountFactory
    {
        private readonly bool _isGeneratedError;
        
        public Account Result { get; private set; }

        public AccountFactory(bool isGeneratedError)
        {
            _isGeneratedError = isGeneratedError;
        }

        public Account Create(params string[] rows)
        {
            var lines = new char[Number.MaxRowCnt, Account.NumberCnt * Number.MaxColCnt];
            for (var i = 0; i < rows.Length; i++)
            {
                var row = rows[i].ToCharArray();
                for (var j = 0; j < row.Length; j++)
                {
                    lines[i, j] = rows[i][j];
                }
            }

            return new Account(lines);
        }

        public Account Create(string accountStr)
        {
            var lines = new char[Number.MaxRowCnt, Account.NumberCnt * Number.MaxColCnt];
            var accountChars = accountStr.ToCharArray();
            for (var accCnt = 0; accCnt < accountChars.Length; accCnt++)
            {
                if (Definitions.Numbers.TryGetValue((accountChars[accCnt] - '0'), out var charChain))
                {
                    var mply = accCnt > 0 ? accCnt * Number.MaxColCnt : 0;
                    for (var colCnt = 0; colCnt < Number.MaxColCnt; colCnt++)
                    {                        
                        if (_isGeneratedError && new Random().Next(100) >= 99)
                        {
                            lines[0, (mply + colCnt)] = charChain[colCnt, 0];
                            lines[1, (mply + colCnt)] = charChain[colCnt, 1];
                            lines[2, (mply + colCnt)] = charChain[colCnt, 2];
                        }
                        else
                        {
                            lines[0, (mply + colCnt)] = charChain[0, colCnt];
                            lines[1, (mply + colCnt)] = charChain[1, colCnt];
                            lines[2, (mply + colCnt)] = charChain[2, colCnt];
                        }                   
                    }
                }
            }

            return new Account(lines);
        }
    }
}
