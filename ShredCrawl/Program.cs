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

            var crawlTarget = "https://www.pinkbike.com/news/movies-for-your-monday-october9-2017.html";

            Crawler.Crawl(crawlTarget);

            vidsToAdd.AddRange(Crawler.YouTubeCollect());
            vidsToAdd.AddRange(Crawler.VimeoCollect());
            vidsToAdd.AddRange(Crawler.PinkBikeCollect());

            Console.WriteLine("Crawl Completed. Found " + vidsToAdd.Count + " new videos. Press anything to add them to the database.");
            Console.ReadLine();

            foreach (WebVid webVid in vidsToAdd)
            {
                DbInterface.AddToDb(webVid);
            }

            Console.WriteLine(vidsToAdd.Count + " new videos added to the database!");
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
