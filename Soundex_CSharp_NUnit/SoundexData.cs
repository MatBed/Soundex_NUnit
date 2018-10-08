using System.Collections.Generic;

namespace Soundex_CSharp_NUnit
{
    public class SoundexData
    {
        public Dictionary<string, string> charToNumber;

        public SoundexData()
        {
            charToNumber = new Dictionary<string, string>();

            charToNumber.Add("b", "1");
            charToNumber.Add("f", "1");
            charToNumber.Add("p", "1");
            charToNumber.Add("v", "1");

            charToNumber.Add("c", "2");
            charToNumber.Add("g", "2");
            charToNumber.Add("j", "2");
            charToNumber.Add("k", "2");
            charToNumber.Add("q", "2");
            charToNumber.Add("s", "2");
            charToNumber.Add("x", "2");
            charToNumber.Add("z", "2");

            charToNumber.Add("d", "3");
            charToNumber.Add("t", "3");

            charToNumber.Add("l", "4");

            charToNumber.Add("m", "5");
            charToNumber.Add("n", "5");

            charToNumber.Add("r", "6");
        }
    }
}
