using System.Collections.Generic;

namespace FaxReader.Lib
{
    /// <summary>
    /// Fájl szolgáltatás interfésze.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// A megadott útvonalra létrehozza a fájlt, létrehozza, vagy újralétrehozza, és a paraméterül átadott string tömböt soronként elmenti a fájltartalmába.
        /// </summary>
        /// <param name="filePath">A menteni kívánt fájl útvonala (abszolút, relatív).</param>
        /// <param name="array">A string tömb amelyet menteni szeretnénk a fájlba.</param>
        void SaveToFile(string filePath, IEnumerable<string> array);
        /// <summary>
        /// Felolvassa az útvonalban megadott fájlt soronként, majd egy tömbben adja vissza.
        /// </summary>
        /// <param name="filePath">A felolvasnikívánt fájl</param>
        /// <returns>A felolvasott fájl sorai string tömbben.</returns>
        string[] ReadFromFile(string filePath);
    }
}
