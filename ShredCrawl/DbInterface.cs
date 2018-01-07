using System;
using System.Linq;

namespace ShredCrawl
{
    internal class DbInterface
    {
        
        public static void AddToDb(WebVid webVid)
        {
            using (var db = new PerpetualShredContext_0B395B8309F4411697C6Eb6C19F89Ae2Context())
            {
                if ((webVid.Title == null) || (webVid.Synopsis == null) || (webVid.Title == "") || (webVid.Synopsis == ""))
                {
                    return;
                }

                if (db.WebVid.Any(o => o.PlayerUrl == webVid.PlayerUrl))
                {
                }

                else
                {
                    db.Add(webVid);
                    db.SaveChanges();
                    Console.WriteLine(@"using Local DB");
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
