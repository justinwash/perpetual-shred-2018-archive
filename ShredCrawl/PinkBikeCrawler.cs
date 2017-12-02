using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Collections;

namespace ShredCrawl
{
    class PinkBikeCrawler
    {
        HtmlDocument homePage = new HtmlWeb().Load("http://www.pinkbike.com");

        public List<WebVid> CrawlPinkBike()
        {
            var linksToCrawl = new List<HtmlDocument>();
            var vidList = new List<WebVid>();
            
            foreach (HtmlDocument vidPage in linksToCrawl)
            {
                vidList.AddRange(YouTubeInterface.YouTubeCollect(vidPage));
                vidList.AddRange(VimeoInterface.VimeoCollect(vidPage));
                vidList.AddRange(PinkBikeInterface.PinkBikeCollect(vidPage));
            }

            return vidList;
        }
    }
}
