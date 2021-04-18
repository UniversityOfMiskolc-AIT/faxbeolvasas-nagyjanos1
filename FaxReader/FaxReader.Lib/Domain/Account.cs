using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaxReader.Lib
{
    public class Account
    {
        public const int NumberCnt = 9;

        public char[,] Lines { get; private set; }
        public List<Number> Numbers { get; private set; }
        public bool HasIllegalChar { get; set; }

        public Account(char[,] lines)
        {
            Lines = lines;
        }

        public void Parse()
        {
            Numbers = new List<Number>();
            for (var i = 0; i < NumberCnt * Number.MaxColCnt; i += Number.MaxColCnt)
            {
                var number = new Number();
                for (var j = i; j < (i + Number.MaxColCnt); j++)
                {
                    var rowCnt = j < Number.MaxRowCnt ? j : j % Number.MaxRowCnt;
                    for (var k = 0; k < Number.MaxRowCnt; k++)
                    {
                        number.Lines[k, rowCnt] = Lines[k, j];
                    }
                }

                if (number.Parse() == null)
                {
                    HasIllegalChar = true;
                }

                Numbers.Add(number);
            }
        }

        public string GetValue()
        {
            if (Numbers == null || !Numbers.Any())
            {
                throw new InvalidOperationException("Firstly, you have to call Parse method");
            }

            var sb = new StringBuilder();
            foreach (var number in Numbers)
            {
                if (number.Value.HasValue)
                {
                    sb.Append(number.ToString());
                }                
            }

            return sb.ToString();
        }

        internal IEnumerable<string> ToStringArray()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Number.MaxRowCnt; i++)
            {
                sb.Clear();

                for (var j = 0; j < Account.NumberCnt * Number.MaxColCnt; j++)
                {
                    sb.Append(Lines[i, j]);
                }

                yield return sb.ToString();
            }
        }
    }
}
