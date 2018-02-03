using System;
using System.Linq;

namespace ShredCrawl
{
    internal class DbDataManager
    {
        
        public static void AddToDb(WebVid webVid)
        {
            using (var db = new PerpetualShredContext())
            {
                if ((webVid.Title == null) || (webVid.Synopsis == null) || (webVid.Title == "") || (webVid.Synopsis == ""))
                {
                    return;
                }

                if (db.WebVid.Any(o => o.PlayerUrl == webVid.PlayerUrl))
                {
                    Console.WriteLine("Duplicate found : " + webVid.Title);
                }

                else
                {
                    db.Add(webVid);
                    db.SaveChanges();
                    Console.WriteLine(@"Origin Url: " + webVid.OriginUrl);
                    Console.WriteLine(@"Origin Title: " + webVid.OriginTitle);
                    Console.WriteLine(@"Player Url: " + webVid.PlayerUrl);
                    Console.WriteLine($@"Title: ""{webVid.Title}""");
                    Console.WriteLine(@"Synopsis: " + webVid.Synopsis);
                    Console.WriteLine(@"Release Date: " + webVid.ReleaseDate);
                    Console.WriteLine();
                }
            }
        }
    }
}
