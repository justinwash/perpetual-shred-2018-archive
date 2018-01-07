using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace ShredCrawl
{
    internal class PinkBikeCrawler
    {
        private HtmlDocument _homePage = new HtmlWeb().Load("https://www.pinkbike.com/news/videos/");
        
        public List<WebVid> CrawlPinkBike()
        {
            var pagesToCrawl = GetPostUrls();
            
            var vidList = new List<WebVid>();
            

            foreach (var vidPage in pagesToCrawl)
            {
                vidList.AddRange(YouTubeInterface.YouTubeCollect(vidPage.Doc));
                vidList.AddRange(VimeoInterface.VimeoCollect(vidPage.Doc));
                vidList.AddRange(PinkBikeInterface.PinkBikeCollect(vidPage.Doc, vidPage.Url));
            }

            return vidList;
        }

        public List<PinkBikePage> GetPostUrls()
        {
            var posts = _homePage.DocumentNode.SelectNodes("/html/body/div[4]/div/div[1]/div/div/div[1]/div[2]/div[2]/div");
            var vidPageLink = new Regex("<a class=\"f22 fgrey4 bold\" href=\"(.*?)>");

            var postList = new List<PinkBikePage>();

            foreach (var postNode in posts)
            {
                //Console.WriteLine(postNode.OuterHtml);
                var vidPageMatches = vidPageLink.Match(postNode.OuterHtml);

                if (vidPageMatches.Success)
                {
                    var pageToAdd = new PinkBikePage();
                    var rawLink = vidPageMatches.Value;
                    var linkLength = rawLink.Length - 35;
                    var truncLink = rawLink.Substring(33, linkLength);
                    Console.WriteLine(@"Found post! " + truncLink);
                    pageToAdd.Url = truncLink;
                    pageToAdd.Doc = new HtmlWeb().Load(truncLink);
                    postList.Add(pageToAdd);
                }
            }

            return postList;
        }
            
    }
}
