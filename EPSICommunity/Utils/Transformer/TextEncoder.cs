using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSICommunity.Utils.Transformer
{
    public class TextEncoder
    {
        public static String EncodeText(String textToEncode)
        {
            return textToEncode.Replace(" ", "&#x20;").Replace("\t", "&#xA7;").Replace("\r\n", "&#x0A;").Replace("\"", "&#x22;").Replace("'", "&#x27;");
        }

        public static String DecodeText(String textToDecode)
        {
            return textToDecode.Replace("&#x20;", " ").Replace("&#xA7;", "\t").Replace("&#x0A;", "\n").Replace("&#x22;", "\"").Replace("&#x27;", "'");
        }
    }
}
