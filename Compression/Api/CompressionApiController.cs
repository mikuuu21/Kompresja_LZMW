using Compression.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Compression.Api
{
    [RoutePrefix("api/compression")]
    public class CompressionApiController : ApiController
    {
        [Route("compress")]
        public IHttpActionResult GetCompress(string text)
        {
           var textToCompress = FileReader.ConvertToBase64(text);

            string compressedFile = "";

            Encoder encoder = new Encoder();

            List<int> compressed = encoder.Compress(textToCompress);

            Dictionary<int, string> dict = DictInitialize.DeompressDictionaryInit();

            foreach (var item in compressed)
            {
                compressedFile += item + ",";

            }
            int beforeCompression = textToCompress.Count();
            int afterCompression = compressed.Count();


            return Json(new { compressedFile, beforeCompression, afterCompression });
        }

        [Route("decompress")]
        public IHttpActionResult GetDeCompress(string text)
        {
            List<int> compressedValue = new List<int>();

            foreach (var item in text.Split(','))
            {
                if (!string.IsNullOrEmpty(item))
                {
                    int value = Int32.Parse(item);
                    compressedValue.Add(value);
                }

            }

            Decompression decoder = new Decompression();
            var decompressed = decoder.Decompress(compressedValue);
            byte[] data = Convert.FromBase64String(decompressed);
            string decodedString = System.Text.Encoding.UTF8.GetString(data);
            return Json(new { decodedString });
        }

    }
}
