using System.Collections.Generic;
using System.IO;

namespace FaxReader.Lib
{
    public class FileService : IFileService
    {
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
