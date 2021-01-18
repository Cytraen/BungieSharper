using System.IO;
using System.Text;

namespace BungieSharper.Generator.Generation
{
    internal static class FileWriter
    {
        public static void WriteFileWithContent(string fileFolder, string fileName, string fileContent)
        {
            Directory.CreateDirectory(fileFolder);

            File.WriteAllText(fileFolder + "\\" + fileName, fileContent.Replace("\r\n", "\n").Replace("\n", "\r\n"), Encoding.UTF8);
        }
    }
}