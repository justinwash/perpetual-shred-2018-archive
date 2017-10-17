using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ShredCrawl
{
    class Crawler
    {
        static Regex youtubeMatch = new Regex("youtu(?:.be|be.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]).+?(?=\")");
        static Regex vimeoMatch = new Regex("(player.)?(vimeo.com)/(video/)?([0-9]+)");
        static Regex pinkbikeMatch = new Regex("(data-videoid=\")([0-9]+)\"");
        static string pbPreceder = "www.pinkbike.com/v/embed/";

        public static List<WebVid> YouTubeCrawl(string crawlTarget)
        {
            var ytVidList = new List<WebVid>();

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(crawlTarget);
            var ytNodes = htmlDoc.DocumentNode.SelectNodes("//iframe");

            foreach (HtmlNode node in ytNodes)
            {
                Match youtubeMatches = youtubeMatch.Match(node.OuterHtml);

                if (youtubeMatches.Success)
                {
                    WebVid ytVidToAdd = new WebVid();

                    string input = youtubeMatches.Value;
                    Console.WriteLine("Youtube match: " + input);

                    ytVidToAdd.PlayerUrl = input;

                    ytVidList.Add(ytVidToAdd);

                }
            }

            return ytVidList;
        }

        public static List<WebVid> VimeoCrawl(string crawlTarget)
        {
            var vmVidList = new List<WebVid>();

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(crawlTarget);
            var vmNodes = htmlDoc.DocumentNode.SelectNodes("//iframe");

            foreach (HtmlNode node in vmNodes)
            {
                Match vimeoMatches = vimeoMatch.Match(node.OuterHtml);

                if (vimeoMatches.Success)
                {
                    WebVid vmVidToAdd = new WebVid();

                    string input = vimeoMatches.Value;
                    Console.WriteLine("Vimeo match: " + input);

                    vmVidToAdd.PlayerUrl = input;

                    vmVidList.Add(vmVidToAdd);

                }
            }

            return vmVidList;
        }

        public static List<WebVid> PinkBikeCrawl(string crawlTarget)
        {
            var pbVidList = new List<WebVid>();

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(crawlTarget);
            var pbNodes = htmlDoc.DocumentNode.SelectNodes("//video");

            foreach (HtmlNode node in pbNodes)
            {
                Match pbMatches = pinkbikeMatch.Match(node.OuterHtml);

                if (pbMatches.Success)
                {
                    WebVid pbVidToAdd = new WebVid();

                    string input = pbMatches.Value;
                    string pbLink = pbPreceder + input.Substring(14, 6);
                    Console.WriteLine("PinkBike match: " + pbLink);

                    pbVidToAdd.PlayerUrl = pbLink;
                    pbVidList.Add(pbVidToAdd);
                }
            }

            return pbVidList;
        }
    }
}
