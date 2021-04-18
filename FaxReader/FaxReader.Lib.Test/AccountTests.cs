using NUnit.Framework;
using System.Linq;

namespace FaxReader.Lib.Test
{
    class AccountTests
    {
        [TestCase(
            "    _  _  _     _  _  _  _ ",
            "  ||_  _|  |  ||_  _|  |  |",
            "  | _| _|  |  | _| _|  |  |"
        )]
        public void ParseTest2(params string[] input)
        {
            var lines = Convert(input);
            var account = new Account(lines);
            account.Parse();
            Assert.AreEqual("153715377", account.GetValue());
        }

        [TestCase(
            "    _  _  _ ||| _  _  _  _ ",
            "  ||_  _|  |||||_  _|  |  |",
            "  | _| _|  |||| _| _|  |  |"
        )]
        public void ParseTest3(params string[] input)
        {
            var lines = Convert(input);
            var account = new Account(lines);
            account.Parse();
            Assert.AreEqual("15375377", account.GetValue());
        }


        [TestCase(
            " _     _  _  _  _  _  _    ",
            "| |  || || || || || || |  |",
            "|_|  ||_||_||_||_||_||_|  |"
        )]
        public void ParseTest4(params string[] input)
        {
            var lines = Convert(input);
            var account = new Account(lines);
            account.Parse();
            Assert.AreEqual("010000001", account.GetValue());
        }

        private char[,] Convert(string[] input)
        {
            char[][] jaggedChars = input.Select(x => x.ToCharArray()).ToArray();
            char[,] charArray = new char[jaggedChars.Length, jaggedChars[0].Length];
            for (var i = 0; i < jaggedChars.Length; i++)
            {
                for (var j = 0; j < jaggedChars[i].Length; j++)
                {
                    charArray[i, j] = jaggedChars[i][j];
                }
            }

            return charArray;
        }
    }
}