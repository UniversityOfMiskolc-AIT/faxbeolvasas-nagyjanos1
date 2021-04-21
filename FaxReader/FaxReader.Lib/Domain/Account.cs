using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaxReader.Lib
{
    /// <summary>
    /// Egy darab számlaszámot reprezentáló osztály.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Egy számlaszám hány darab számból állhat.
        /// </summary>
        public const int NumberCnt = 9;

        /// <summary>
        /// A számla számainak nyers sorai. 3*9 dimenziós tömb.
        /// </summary>
        public char[,] Lines { get; private set; }

        /// <summary>
        /// A számla számai.
        /// </summary>
        public List<Number> Numbers { get; private set; }

        /// <summary>
        /// A számla tartalmaz-e illegális karaktert
        /// </summary>
        public bool HasIllegalChar { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lines">Nyers sorok, amelyból a számla áll. Ez egy 3*9 dimenziós tömb.</param>
        public Account(char[,] lines)
        {
            Lines = lines;
        }

        /// <summary>
        /// A konstruktorban átadott nyerssorokat alakítja át szám modellekké.
        /// </summary>
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

        /// <summary>
        /// Végig iterál a számokon, amelyek alkotják a számlát, majd összefűzi őket egy stringbe.
        /// </summary>
        /// <example>
        /// 123456789
        /// </example>
        /// <returns>A számla string típusú reprezentációja.</returns>
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

        /// <summary>
        /// A konstruktorban átadott számla nyerssorait, string tömbökként adja vissza.
        /// </summary>
        /// <example>
        /// "    _  _  _     _  _  _  _ ",
        /// "  ||_  _|  |  ||_  _|  |  |",
        /// "  | _| _|  |  | _| _|  |  |"
        /// </example>
        /// <returns>A számla fax formátumban string tömbként reprezentálva.</returns>
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
