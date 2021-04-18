using System.Collections.Generic;

namespace FaxReader.Lib
{
    public static class Definitions     
    {
        public const char w = ' ';
        public const char l = '|';
        public const char u = '_';

        public static char[,] Zero = {{ w, u, w },
                                      { l, w, l },
                                      { l, u, l }};
        public static char[,] One = {{ w, w, w },
                                     { w, w, l },
                                     { w, w, l }};
        public static char[,] Two = {{ w, u, w },
                                     { w, u, l },
                                     { l, u, w }};
        public static char[,] Three = {{ w, u, w },
                                       { w, u, l },
                                       { w, u, l }};
        public static char[,] Four = {{ w, w, w },
                                      { l, u, l },
                                      { w, w, l }};
        public static char[,] Five = {{ w, u, w },
                                      { l, u, w },
                                      { w, u, l }};
        public static char[,] Six = {{ w, u, w },
                                     { l, u, w },
                                     { l, u, l }};
        public static char[,] Seven = {{ w, u, w },
                                       { w, w, l },
                                       { w, w, l }};
        public static char[,] Eight = {{ w, u, w },
                                       { l, u, l },
                                       { l, u, l }};
        public static char[,] Nine = {{ w, u, w },
                                      { l, u, l },
                                      { w, u, l }};

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
