using System;
using System.Collections.Generic;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.Extensions.Configuration;

namespace ShredCrawl
{
    internal static class Program
    {
        private static void Main()
        {
            
            var vidsToAdd = new List<WebVid>();
            var pbCrawler = new Crawlers.PinkBikeCrawler();

            vidsToAdd.AddRange(pbCrawler.CrawlPinkBike());

            Console.WriteLine(@"Crawled PinkBike dude! Found " + vidsToAdd.Count + @" videos. Adding new ones to the database.");

            foreach (var webVid in vidsToAdd)
            {
                DbDataManager.AddToDb(webVid);
            }
            Console.WriteLine("DONE!");
            Console.ReadLine();
        }
    }
}
