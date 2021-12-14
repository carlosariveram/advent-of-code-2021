using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Console.Helpers
{
    internal class FileHelper
    {
        private static string GetInputFilePath(string fileName) => Path.Combine(Directory.GetCurrentDirectory(), "Resources", fileName);

        public static string[] GetInputFromFile(string fileName)
        {
            var filePath = GetInputFilePath(fileName);
            var input = File.ReadAllLines(filePath);

            return input;
        }
    }
}
