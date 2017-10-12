using System;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ShredCrawl
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex rx = new Regex(@"youtube.com/embed/.*$");
            
            var html = "https://www.pinkbike.com/news/movies-for-your-monday-october9-2017.html";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            var nodes = htmlDoc.DocumentNode.SelectNodes("//iframe");

            /*
            foreach ( HtmlNode node in nodes)
             {
                MatchCollection matches = rx.Matches(node.OuterHtml);
                Console.WriteLine("{0} matches found in:\n   {1}",
                         matches.Count,
                         text);
            }
            */

            nodes.RemoveAt(0);
            foreach (HtmlNode node in nodes) {
                Match matches = rx.Match(node.OuterHtml);
                if (matches.Success)
                {
                    string input = matches.Value;
                    int index = input.IndexOf("\"");
                    if (index > 0)
                        input = input.Substring(0, index);
                    Console.WriteLine(input);
                }
            }

            Console.ReadLine();
        }
    }
}
