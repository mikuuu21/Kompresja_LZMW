using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            if (input.Count() == 0)
            {
                throw new CustomExceptions("Plik nie zawiera żadnych znaków");
            }




            return inp;





        }
    }
}