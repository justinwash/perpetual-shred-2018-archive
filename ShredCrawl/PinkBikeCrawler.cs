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
        HtmlDocument homePage = new HtmlWeb().Load("https://www.pinkbike.com/news/videos");

        public List<WebVid> CrawlPinkBike()
        {
            var linksToCrawl = GetPostUrls();
            var vidList = new List<WebVid>();

            foreach (HtmlDocument vidPage in linksToCrawl)
            {
                vidList.AddRange(YouTubeInterface.YouTubeCollect(vidPage));
                vidList.AddRange(VimeoInterface.VimeoCollect(vidPage));
                //vidList.AddRange(PinkBikeInterface.PinkBikeCollect(vidPage));
            }

            return vidList;
        }

        public List<HtmlDocument> GetPostUrls()
        {
            var posts = homePage.DocumentNode.SelectNodes("/html/body/div[4]/div/div[1]/div/div/div[1]/div[2]/div[2]/div");
            Regex vidPageLink = new Regex("<a class=\"f22 fgrey4 bold\" href=\"(.*?)>");

            var postList = new List<HtmlDocument>();

            foreach (HtmlNode postNode in posts)
            {
                //Console.WriteLine(postNode.OuterHtml);
                Match vidPageMatches = vidPageLink.Match(postNode.OuterHtml);

                if (vidPageMatches.Success)
                {
                    string rawLink = vidPageMatches.Value;
                    int linkLength = rawLink.ToString().Length - 35;
                    string truncLink = rawLink.Substring(33, linkLength);
                    Console.WriteLine("Found post! " + truncLink);
                    postList.Add(new HtmlWeb().Load(truncLink));
                }
            }

            return postList;
        }
            
    }
}
