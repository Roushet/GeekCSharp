using System;
using System.Net;
using System.Text.RegularExpressions;

namespace Task
{
    class Program
    {
        //6. ***В заданной папке найти во всех html файлах теги<img src=...> и вывести названия картинок.Использовать регулярные выражения.
        static void Main(string[] args)
        {
            string address;
            address = @"https://lenta.ru/news/2017/12/18/uralez/";
            //address = @"https://hi-tech.mail.ru/";
            WebClient client = new WebClient();

            string content = client.DownloadString(address);

            string pattern = "src=\\\"([^\\\"]*(jpg|png))\\\"";

            MatchCollection result = Regex.Matches(content, pattern);
            foreach (var entry in result) Console.WriteLine(entry.ToString().Trim('\"').Substring(5));

            Console.ReadKey();
        }
    }
}
