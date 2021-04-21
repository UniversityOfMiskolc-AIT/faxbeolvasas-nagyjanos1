using System;
using System.Collections.Generic;

namespace FaxReader.Lib
{
    /// <summary>
    /// Számlaszámokat fax formátumba generáló osztály.
    /// </summary>
    internal class AccountGenerator
    {
        private readonly int _startNumber;
        private readonly int _count;
        private readonly bool _hasGeneratedIllegalChar;

        /// <summary>
        /// A legenerált számlaszámok fax formátumban.
        /// </summary>
        public List<string> Accounts { get; private set; }

        /// <summary>
        /// privát adattagok és az Accounts Property inicializálása.
        /// </summary>
        /// <param name="startNumber">A kezdeti szám, amelytől indul a generálás.</param>
        /// <param name="count">A generálandó számlaszámok száma.</param>
        /// <param name="hasGeneratedIllegalChar">Tartalmazzon-e illegális karaktereket a generált számlaszám.</param>
        public AccountGenerator(int startNumber, int count, bool hasGeneratedIllegalChar)
        {
            _startNumber = startNumber;
            _count = count;
            _hasGeneratedIllegalChar = hasGeneratedIllegalChar;
            Accounts = new List<string>();
        }

        /// <summary>
        /// Számlaszámok legenerálása.
        /// Amennyiben a _hasGeneratedIllegalChar=true 75 százalékos valószínűséggel generál hibás ellenőrzőszám összegű számlaszámot.
        /// </summary>
        public void Generate()
        {
            var count = 0;
            var number = _startNumber;
            do
            {                
                var str = $"{number}";
                var sum = 0;
                for (var i = 0; i < str.Length; i++)
                {
                    sum += (str[i] - '0') * (i + 1);
                }

                if (sum % 11 == 0)
                {      
                    if (_hasGeneratedIllegalChar)
                    {
                        var randonNum = (new Random()).Next(100);
                        if (randonNum > 75)
                        {
                            Accounts.Add($"{number - randonNum}");
                        }
                        else
                        {
                            Accounts.Add(str);
                        }
                    }
                    else
                    {
                        Accounts.Add(str);
                    }                    
                    count++;
                }

                number++;
            }
            while (count < _count);
        }
    }
}
