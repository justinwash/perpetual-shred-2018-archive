using System;
using System.Collections.Generic;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace ShredCrawl
{
    internal static class Program
    {
        private static void Main()
        {
            var vidsToAdd = new List<WebVid>();
            var pbCrawler = new Crawlers.PinkBikeCrawler();

            vidsToAdd.AddRange(pbCrawler.CrawlPinkBike());

            Console.WriteLine(@"Crawled PinkBike dude! Found " + vidsToAdd.Count + @" videos. Press anything to add the new ones to the Db.");
            Console.ReadLine();

            foreach (var webVid in vidsToAdd)
            {
                DbDataManager.AddToDb(webVid);
            }
            Console.WriteLine("DONE!");
            Console.ReadLine();
        }
    }
}
