namespace FaxReader.Lib
{
    /// <summary>
    /// A számla 1 darab számát reprezántaló osztály.
    /// </summary>
    public class Number 
    {
        /// <summary>
        /// Maximális karakter sorokszáma, amelyből összeáll egy szám.
        /// </summary>
        public const int MaxRowCnt = 3;

        /// <summary>
        /// Maximális karakter oszlopokszáma, amelyből összeáll egy szám.
        /// </summary>
        public const int MaxColCnt = 3;

        /// <summary>
        /// A száma értéke. Az érték null, ha nem található mappelhetőségi szótárban.
        /// </summary>
        public int? Value { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public char[,] Lines { get; set; }

        /// <summary>
        /// Inicializálja a Lines property-t
        /// </summary>
        public Number()
        {
            Lines = new char[MaxRowCnt, MaxColCnt];
        }

        /// <summary>
        /// A definiált számok közül megvizsgálja melyik illik a nyers sorok mintáira, majd a megtalált számot beállítja értékként,
        /// majd visszaadja visszatérési értékként.
        /// </summary>
        /// <returns></returns>
        public int? Parse()
        {
            foreach (var number in Definitions.Numbers)
            {
                var hit = true;
                for (var i = 0; i < MaxRowCnt; i++)
                {
                    for (var j = 0; j < MaxColCnt; j++)
                    {
                        if (number.Value[i, j] != Lines[i, j])
                        {
                            hit = false;
                            break;
                        }
                    }

                    if (!hit) break;
                }

                if (hit)
                {
                    Value = number.Key;
                    break;
                }
            }

            return Value;
        }

        /// <summary>
        /// Az érték string reprezentációja.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value?.ToString();
        }
    }
}
