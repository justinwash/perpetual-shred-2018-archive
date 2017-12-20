using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;


namespace ShredCrawl
{
    class Program
    {
        static void Main(string[] args)
        {
            var vidsToAdd = new List<WebVid>();
            PinkBikeCrawler pbCrawler = new PinkBikeCrawler();
            DbInterface dB = new DbInterface();

            vidsToAdd.AddRange(pbCrawler.CrawlPinkBike());

            Console.WriteLine("Crawled PinkBike dude! Found " + vidsToAdd.Count + " new videos. Press Enter to add them to the database.");
            Console.ReadLine();

            foreach (WebVid webVid in vidsToAdd)
            {
                dB.AddToDb(webVid);
            }

            Console.WriteLine("SENT 'em to the database! (get it???)");
            Console.ReadLine();
        }

        public static YouTubeService YoutTubeAuthorize()
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = YouTubeSettings.apiKey,
                ApplicationName = YouTubeSettings.appName
            });

            return youtubeService;
        }
    }
}
