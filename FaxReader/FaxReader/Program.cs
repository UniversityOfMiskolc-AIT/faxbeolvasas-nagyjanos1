using System;
using System.Globalization;
using System.Linq;
using FaxReader.Lib;

namespace FaxReader
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!args.Any())
            {
                Console.WriteLine();
                Console.WriteLine("NAME:");
                Console.WriteLine("\t BankManager.Account.Program - Generate Bank accounts or check their formats");
                Console.WriteLine();
                Console.WriteLine("SYNOPSIS:");
                Console.WriteLine("\t BankManager.Account.Program filename [OPTION]... ");
                Console.WriteLine();
                Console.WriteLine("DESCRIPTION:");
                Console.WriteLine("This application works with Bank accounts. It is able to generate or check them.");
                Console.WriteLine("The application will save result to a report file, whose name consists of the original file name and \"-result postfix\". The extension will remain same.");
                Console.WriteLine();
                Console.WriteLine("\t -g,-G");
                Console.WriteLine("\t\t Generate bank accounts");
                Console.WriteLine();
                Console.WriteLine("\t -s,-S");
                Console.WriteLine("\t\t This is the start number of generation. The default value is 100000000.");
                Console.WriteLine();
                Console.WriteLine("\t -n,-N");
                Console.WriteLine("\t\t You can set to how many accounts will have generated. The default value is 500.");
                Console.WriteLine();
                Console.WriteLine("EXAMPLE:");
                Console.WriteLine("\t BankManager.Account.Program accounts.txt -G -S 123456789 -N 500");
                Console.WriteLine("\t BankManager.Account.Program accounts.txt");
                Console.WriteLine();
            }

            var timer = new System.Timers.Timer();
            timer.Start();

            var accountService = new AccountService(new AccountFactory(true));
            var fileService = new FileService();

            if (args.Length > 1 && args[1].ToLower() == "-g")
            {
                Console.WriteLine($"Generating in progress to {args[0]} file.");
                Console.WriteLine();

                var startNumber = GetArguments(args.ElementAtOrDefault(2), args.ElementAtOrDefault(3));
                var accountCnt = GetArguments(args.ElementAtOrDefault(4), args.ElementAtOrDefault(5));

                var rows = accountService.GenerateInDigitFormat(startNumber, accountCnt);

                fileService.SaveToFile(args[0], rows);
            }
            else
            {
                Console.WriteLine($"The {args[0]} file was read.");

                var rows = fileService.ReadFromFile(args[0]);
                var accounts = accountService.ParseBankAccounts(rows);
                var numbers = accountService.ValidateAccounts(accounts);

                var resultFileName = args[0].Contains('.') ? args[0].Split('.')[0] : args[0];

                fileService.SaveToFile($"{resultFileName}-result.txt", numbers);

                Console.WriteLine($"Report file was created. {resultFileName}-result.txt");
            }

            timer.Stop();
            Console.WriteLine(string.Format(CultureInfo.CreateSpecificCulture("hu-HU"), "Finished {0} ms", (timer.Interval / 60 / 60).ToString("0.##")));

            Console.ReadKey();
        }

        /// <summary>
        /// A metódus meghívásával biztosítjuk, hogy biztos a megfelelő argumentumokat hívták meg a programot.
        /// </summary>
        /// <param name="option">Az kapcsoló paraméte.r</param>
        /// <param name="value">A kapcsoló paraméter értéke string ként.</param>
        /// <returns>A kapcsoló paraméter értéke.</returns>
        public static int? GetArguments(string option, string value)
        {
            if (option == null || value == null)
                return null;

            switch (option)
            {
                case "-S":
                case "-s":
                case "-N":
                case "-n":
                    if (int.TryParse(value, out int argValue))
                    {
                        return argValue;
                    }
                    break;
            };

            return null;
        }
    }
}
