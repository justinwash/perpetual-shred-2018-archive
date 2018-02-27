using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace ShredCrawl.Crawlers
{
    internal class PinkBikeCrawler
    {
        // for current
        private HtmlDocument _homePage = new HtmlWeb().Load("https://www.pinkbike.com/news/videos");
        //for archive. spin this out into it's own thing!
        //private HtmlDocument _homePage = new HtmlWeb().Load("https://www.pinkbike.com/news/archive/?catid=0&year=2017&month=3");
        IVideoCollection _vimcol = new VimeoCollection();
        IVideoCollection _ytcol = new YouTubeCollection();

        public List<WebVid> CrawlPinkBike()
        {
            var pagesToCrawl = GetPostUrls();
            
            var vidList = new List<WebVid>();
            

            foreach (var vidPage in pagesToCrawl)
            {
                vidList.AddRange(_vimcol.Collect(vidPage.Doc));
                vidList.AddRange(_ytcol.Collect(vidPage.Doc));
                vidList.AddRange(Collections.PinkBikeCollection.Collect(vidPage.Doc, vidPage.Url));
            }

            return vidList;
        }

        public List<PinkBikePage> GetPostUrls()
        {
            // For current
             var posts = _homePage.DocumentNode.SelectNodes("/html/body/div[4]/div/div[1]/div/div/div[1]/div[2]/div[2]/div");
            
            //for archive. spin this out into it's own thing!
            // var posts = _homePage.DocumentNode.SelectNodes("/html/body/div[4]/div/div[1]/div/div/div/div[2]/div[3]/div");
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
