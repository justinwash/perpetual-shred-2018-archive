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
                webVid.PlayerUrl = "http://www." + webVid.PlayerUrl + "?rel=0&autoplay=1&amp;showinfo=0";

                db.Add(webVid);
                db.SaveChanges();
                Console.WriteLine("WebVid object with PlayerUrl "
                    + webVid.PlayerUrl + " passed to DbInterface.");
                Console.WriteLine();


            }
        }
    }
}
