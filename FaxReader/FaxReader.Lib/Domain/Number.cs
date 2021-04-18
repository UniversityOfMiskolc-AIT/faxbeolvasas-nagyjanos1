namespace FaxReader.Lib
{
    public class Number 
    {
        public const int MaxRowCnt = 3;
        public const int MaxColCnt = 3;

        public int? Value { get; private set; }
        public char[,] Lines { get; set; }

        public Number()
        {
            Lines = new char[MaxRowCnt, MaxColCnt];
        }

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

        public override string ToString()
        {
            return Value?.ToString();
        }
    }
}
