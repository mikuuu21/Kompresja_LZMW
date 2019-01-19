using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Compression.Classes
{
    public class FileReader
    {

        public static string ReadFile(string path)
        {
            //string input = File.ReadAllText(path, ASCIIEncoding.Default);
            byte[] input = File.ReadAllBytes(path);
            //var inp = Convert.ToBase64String(input);
            var inp = System.Text.Encoding.ASCII.GetString(input);
            CheckIfEmpty(inp);

            return inp;
        }

        public static string ConvertToBase64(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            string input = Convert.ToBase64String(bytes);
            CheckIfEmpty(input);

            return input;
        }

        public static string ConvertToAscii(string text)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            string input = Encoding.ASCII.GetString(bytes);
            CheckIfEmpty(input);

            return input;
        }

        public static string ReadFile(byte[] file)
        {

            //var inp = Convert.ToBase64String(input);
            var input = System.Text.Encoding.ASCII.GetString(file);
            CheckIfEmpty(input);

            return input;
        }

        private static void CheckIfEmpty(string input)
        {
            if (input.Count() == 0)
            {
                throw new CustomExceptions("Plik nie zawiera żadnych znaków");
            }
        }
    }
}