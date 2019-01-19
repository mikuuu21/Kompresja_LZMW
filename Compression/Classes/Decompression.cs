using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Compression.Classes
{
    public class Decompression
    {

        public Dictionary<int, string> dict;

        public Decompression()
        {
            dict = DictInitialize.DeompressDictionaryInit();
        }


        public string Decompress(List<int> compressedFile)
        {

            string w = dict[compressedFile[0]];
            compressedFile.RemoveAt(0);
            StringBuilder decompressed = new StringBuilder(w);

            foreach (int k in compressedFile)
            {
                string entry = null;
                if (dict.ContainsKey(k))
                    entry = dict[k];
                else if (k == dict.Count)
                    entry = w + w[0];

                decompressed.Append(entry);

                dict.Add(dict.Count, w + entry[0]);

                w = entry;
            }
            return decompressed.ToString();

        }
    }
}