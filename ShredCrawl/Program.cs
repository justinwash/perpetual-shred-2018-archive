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

            Regex youtubeMatch = new Regex("youtu(?:.be|be.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]).+?(?=\")");
            Regex vimeoMatch = new Regex("(player.)?(vimeo.com)/(video/)?([0-9]+)");
            Regex pinkMatch = new Regex("(player.)?(vimeo.com)/(video/)?([0-9]+)");

            var html = "https://www.pinkbike.com/news/movies-for-your-monday-october9-2017.html";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            var ytNodes = htmlDoc.DocumentNode.SelectNodes("//iframe");
            var pbNodes = htmlDoc.DocumentNode.SelectNodes("//video");

            foreach (HtmlNode node in ytNodes)
            {
                Match youtubeMatches = youtubeMatch.Match(node.OuterHtml);
                Match vimeoMatches = vimeoMatch.Match(node.OuterHtml);

                if (youtubeMatches.Success)
                {
                    string input = youtubeMatches.Value;
                    Console.WriteLine("Youtube match: " + input);
                    
                }

                if (vimeoMatches.Success)
                {
                    string input = vimeoMatches.Value;
                    Console.WriteLine("Vimeo match: " + input);

                }
            }

            foreach (HtmlNode node in ytNodes)
            {
                Match pinkMatches = pinkMatch.Match(node.OuterHtml);

                if (pinkMatches.Success)
                {
                    string input = pinkMatches.Value;
                    Console.WriteLine("PinkBike match: " + input);

                }
            }

            Console.ReadLine();
        }
    }
}
