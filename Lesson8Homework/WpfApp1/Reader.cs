using System.Collections.Generic;
using System.IO;

namespace WpfApp1
{
    static class Reader
    {
        public static IEnumerable<string> ReadStringFromfile(string address)
        {
            IEnumerable<string> output;
            output = File.ReadLines(address, System.Text.Encoding.Default);
            //foreach (var str in output) System.Console.WriteLine(str);
            return output;
        }
    }
}
