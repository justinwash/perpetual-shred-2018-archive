using System;
using System.Collections.Generic;
using System.Text;

namespace ShredCrawl
{
    class DbInterface
    {
        public static void AddToDb(WebVid webVid)
        {
            Console.WriteLine("WebVid object with PlayerUrl " 
                + webVid.PlayerUrl + " passed to DbInterface.");
            Console.WriteLine();
        }
    }
}
