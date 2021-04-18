using System;
using System.Collections.Generic;

namespace FaxReader.Lib
{
    internal class AccountGenerator
    {
        private readonly int _startNumber;
        private readonly int _count;
        private readonly bool _hasGeneratedIllegalChar;

        public List<string> Accounts { get; private set; }

        public AccountGenerator(int startNumber, int count, bool hasGeneratedIllegalChar)
        {
            _startNumber = startNumber;
            _count = count;
            _hasGeneratedIllegalChar = hasGeneratedIllegalChar;
            Accounts = new List<string>();
        }

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
