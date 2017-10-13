using System;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace ShredCrawl
{
    class Program
    {
        static void Main(string[] args)
        {

            Regex rx = new Regex(@"embed/([^']*)");
            
            var html = "https://www.pinkbike.com/news/movies-for-your-monday-october9-2017.html";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            var nodes = htmlDoc.DocumentNode.SelectNodes("//iframe");

            foreach (HtmlNode node in nodes) {
                Match matches = rx.Match(node.OuterHtml);
                if (matches.Success)
                {
                    string input = matches.Value;
                    int index = input.IndexOf("\"");
                    if (index > 0)
                        input = input.Substring(6, 11);
                    Console.WriteLine(input);
                    
                }
            }

            Console.ReadLine();
        }
    }
}
