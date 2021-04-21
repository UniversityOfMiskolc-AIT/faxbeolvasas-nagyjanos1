using System;

namespace FaxReader.Lib
{
    /// <summary>
    /// Számlákat előállító osztály. Csak egy darab számlát elő.
    /// </summary>
    public class AccountFactory : IAccountFactory
    {
        private readonly bool _isGeneratedError;
        
        /// <summary>
        /// Az előállított számla
        /// </summary>
        public Account Result { get; private set; }

        /// <summary>
        /// A számlagyár konstruktora.
        /// </summary>
        /// <param name="isGeneratedError">Tartalmazzon-e hibás számokat a legerált számla.</param>
        public AccountFactory(bool isGeneratedError)
        {
            _isGeneratedError = isGeneratedError;
        }

        /// <summary>
        /// A számla (fax formátumú) nyers sorait átalakítja egy 3*27-es mátrixá.
        /// </summary>
        /// <param name="rows">A számla nyers sorai string tömbben reprezentálva.</param>
        /// <returns>Egy számlaobjektum.</returns>
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

        /// <summary>
        /// A számla alfanumerikus karektereiből, mappelési szótárból kiválasztja a megfelelőszámot majd létrehozza a számlaobjektumot.
        /// </summary>
        /// <param name="accountStr">A számla számait reprezentáló string. Alfanumerikus karaktereket tartalmazhat.</param>
        /// <returns>Egy számla objektum.</returns>
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
