using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ShredCrawl
{
    class DbInterface
    {
        
        public static void AddToDb(WebVid webVid)
        {
            using (DbContext db = new PerpetualShredContext_0b395b83_09f4_4116_97c6_eb6c19f89ae2Context())
            {
                if (webVid.VideoService == "YouTube")
                {
                
                webVid.PlayerUrl = "http://www." + webVid.PlayerUrl + "?rel=0&autoplay=1&amp;showinfo=0";
                }

                db.Add(webVid);
                db.SaveChanges();
                Console.WriteLine("WebVid object sent to DB");
                Console.WriteLine("Origin Url: " + webVid.OriginUrl);
                Console.WriteLine("Origin Title: " + webVid.OriginTitle);
                Console.WriteLine("Player Url: " + webVid.PlayerUrl);
                Console.WriteLine("Title: \"" + webVid.Title + "\"");
                Console.WriteLine("Synopsis: " + webVid.Synopsis);
                Console.WriteLine("Release Date: " + webVid.ReleaseDate);
                Console.WriteLine();


            }
        }
    }
}
