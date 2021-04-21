using System.Collections.Generic;
using System.IO;

namespace FaxReader.Lib
{
    /// <summary>
    /// Fájszolgáltatásokat nyújtó osztály.
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        /// Felolvassa az útvonalban megadott fájlt soronként, majd egy tömbben adja vissza.
        /// </summary>
        /// <param name="filePath">A felolvasnikívánt fájl</param>
        /// <returns>A felolvasott fájl sorai string tömbben.</returns>
        public string[] ReadFromFile(string filePath)
        {
            using var readFile = new StreamReader(filePath);
            var tmpLines = new List<string>();
            while (!readFile.EndOfStream)
            {
                if (readFile.EndOfStream)
                    break;

                var line = readFile.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                    tmpLines.Add(line);
            }

            return tmpLines.ToArray();
        }

        /// <summary>
        /// A megadott útvonalra létrehozza a fájlt, létrehozza, vagy újralétrehozza, és a paraméterül átadott string tömböt soronként elmenti a fájltartalmába.
        /// </summary>
        /// <param name="filePath">A menteni kívánt fájl útvonala (abszolút, relatív).</param>
        /// <param name="array">A string tömb amelyet menteni szeretnénk a fájlba.</param>
        public void SaveToFile(string filePath, IEnumerable<string> array)
        {
            using var writtenFile = new StreamWriter(filePath);
            foreach (var row in array)
            {
                writtenFile.WriteLine(row);
            }
        }
    }
}
