using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ShredCrawl
{
    class DbInterface
    {
        
        public void AddToDb(WebVid webVid)
        {
            using (DbContext db = new PerpetualShredContext_0b395b83_09f4_4116_97c6_eb6c19f89ae2Context())
            {
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
