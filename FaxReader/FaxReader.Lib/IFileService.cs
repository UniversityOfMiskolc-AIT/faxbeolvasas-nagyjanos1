using System.Collections.Generic;

namespace FaxReader.Lib
{
    public interface IFileService
    {
        void SaveToFile(string filePath, IEnumerable<string> array);
        string[] ReadFromFile(string filePath);
    }
}
