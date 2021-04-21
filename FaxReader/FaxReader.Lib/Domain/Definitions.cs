using System.Collections.Generic;

namespace FaxReader.Lib
{
    /// <summary>
    /// Számok karaterisztikája.
    /// Minden szám egy 3*3-as mátrixszal reprezentált.
    /// </summary>
    public static class Definitions     
    {
        /// <summary>
        /// "Üres" karakter
        /// </summary>
        public const char w = ' ';

        /// <summary>
        /// Függőleges karakter
        /// </summary>
        public const char l = '|';

        /// <summary>
        /// Vízszintes karakter.
        /// </summary>
        public const char u = '_';

        /// <summary>
        /// A 0 reprezentációja
        /// </summary>
        public static char[,] Zero = {{ w, u, w },
                                      { l, w, l },
                                      { l, u, l }};

        /// <summary>
        /// Az 1 reprezentációja.
        /// </summary>
        public static char[,] One = {{ w, w, w },
                                     { w, w, l },
                                     { w, w, l }};

        /// <summary>
        /// A 2 reprezentációja.
        /// </summary>
        public static char[,] Two = {{ w, u, w },
                                     { w, u, l },
                                     { l, u, w }};

        /// <summary>
        /// A 3 reprezentációja.
        /// </summary>
        public static char[,] Three = {{ w, u, w },
                                       { w, u, l },
                                       { w, u, l }};

        /// <summary>
        /// A 4 reprezentációja.
        /// </summary>
        public static char[,] Four = {{ w, w, w },
                                      { l, u, l },
                                      { w, w, l }};

        /// <summary>
        /// Az 5 reprezentációja.
        /// </summary>
        public static char[,] Five = {{ w, u, w },
                                      { l, u, w },
                                      { w, u, l }};

        /// <summary>
        /// A 6-os szám reprezentációja
        /// </summary>
        public static char[,] Six = {{ w, u, w },
                                     { l, u, w },
                                     { l, u, l }};

        /// <summary>
        /// A 7 reprezentációja.
        /// </summary>
        public static char[,] Seven = {{ w, u, w },
                                       { w, w, l },
                                       { w, w, l }};

        /// <summary>
        /// A 8 reprezentációja.
        /// </summary>
        public static char[,] Eight = {{ w, u, w },
                                       { l, u, l },
                                       { l, u, l }};

        /// <summary>
        /// A 9 reprezentációja.
        /// </summary>
        public static char[,] Nine = {{ w, u, w },
                                      { l, u, l },
                                      { w, u, l }};

        /// <summary>
        /// Mappelhetőségi szótár.
        /// </summary>
        public static Dictionary<int, char[,]> Numbers = new Dictionary<int, char[,]> 
        {
            { 0, Zero },
            { 1, One },
            { 2, Two },
            { 3, Three },
            { 4, Four },
            { 5, Five },
            { 6, Six },
            { 7, Seven },
            { 8, Eight },
            { 9, Nine }
        };
    }
}
