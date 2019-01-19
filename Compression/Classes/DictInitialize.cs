using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Compression.Classes
{
    public class DictInitialize
    {

        public static Dictionary<string, int> CompressDictionaryInit()
        {

            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < 256; i++)
            {
                dict.Add(((char)i).ToString(), i);
                // dict.Add(System.Text.Encoding.Default.GetString(new byte[1] { Convert.ToByte(i) }), i);
            }

            return dict;

        }

        public static Dictionary<int, string> DeompressDictionaryInit()
        {

            Dictionary<int, string> dict = new Dictionary<int, string>();

            for (int i = 0; i < 256; i++)
            {
                dict.Add(i, ((char)i).ToString());

            }

            return dict;

        }

        public static Dictionary<int, int> ByteDict()
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < 256; i++)
            {
                dict.Add((byte)i, i);
                // dict.Add(System.Text.Encoding.Default.GetString(new byte[1] { Convert.ToByte(i) }), i);
            }

            return dict;

        }
    }
}