using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Collections;

namespace ShredCrawl
{
    class Crawler
    {
        static Regex youtubeMatch = new Regex("youtu(?:.be|be.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]).+?(?=\")");
        static Regex vimeoMatch = new Regex("(player.)?(vimeo.com)/(video/)?([0-9]+)");
        static Regex pinkbikeMatch = new Regex("(data-videoid=\")([0-9]+)\"");
        static string pbPreceder = "www.pinkbike.com/v/embed/";

        static HtmlWeb web;
        static HtmlDocument htmlDoc;

        static string crawledPageUrl;

        public static void Crawl(string crawlTarget)
        {
            web = new HtmlWeb();
            htmlDoc = web.Load(crawlTarget);
            crawledPageUrl = crawlTarget;
        }

        public static List<WebVid> YouTubeCollect()
        {
            var ytVidList = new List<WebVid>();
            var ytNodes = htmlDoc.DocumentNode.SelectNodes("//iframe");

            foreach (HtmlNode node in ytNodes)
            { 
                Match youtubeMatches = youtubeMatch.Match(node.OuterHtml);

                if (youtubeMatches.Success)
                {
                    WebVid ytVidToAdd = new WebVid();
                    
                    string input = youtubeMatches.Value;
                    string ytID = input.Substring(18, 11);

                    YouTubeVid tempVid = YouTubeInfo.RetrieveData(ytID);

                    Console.WriteLine("Youtube match: " + input);

                    ytVidToAdd.Title = tempVid.Title;
                    ytVidToAdd.ReleaseDate = tempVid.ReleaseDate;
                    ytVidToAdd.Synopsis = tempVid.Synopsis;
                    ytVidToAdd.PlayerUrl = input;
                    ytVidToAdd.OriginUrl = "http://www.youtube.com/channel/" + tempVid.ChannelID;
                    ytVidToAdd.OriginTitle = tempVid.ChannelTitle + " on YouTube";
                    ytVidToAdd.VideoService = "YouTube";
                    ytVidList.Add(ytVidToAdd);

                }
            }

            return ytVidList;
        }

        public static List<WebVid> VimeoCollect()
        {
            var vmVidList = new List<WebVid>();
            var vmNodes = htmlDoc.DocumentNode.SelectNodes("//iframe");

            foreach (HtmlNode node in vmNodes)
            {
                Match vimeoMatches = vimeoMatch.Match(node.OuterHtml);

                if (vimeoMatches.Success)
                {
                    WebVid vmVidToAdd = new WebVid();

                    string input = vimeoMatches.Value;
                    string vmID = input.Substring(23, 9);
                    Console.WriteLine("Vimeo match: " + input);

                    VimeoVid tempVid = VimeoInfo.RetrieveData(vmID);

                    vmVidToAdd.Title = tempVid.title;
                    vmVidToAdd.ReleaseDate = Convert.ToDateTime(tempVid.upload_date);
                    vmVidToAdd.Synopsis = tempVid.description;
                    vmVidToAdd.PlayerUrl = input;
                    vmVidToAdd.OriginUrl = "http://www.vimeo.com/" + tempVid.user_id;
                    vmVidToAdd.OriginTitle = tempVid.user_name + " on Vimeo";
                    vmVidToAdd.VideoService = "Vimeo";
                    vmVidList.Add(vmVidToAdd);

                }
            }

            return vmVidList;
        }

        public static List<WebVid> PinkBikeCollect()
        {
            var pbVidList = new List<WebVid>();
            var titleList = new ArrayList();
            var synList = new ArrayList();
            var mediaList = new ArrayList();
            var infoNodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'blog-text-container')]");
            var mediaNodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'blog-media-container')]");

            Regex pinkbikeTitle = new Regex("<span(.*?)<");
            Regex pinkbikeSynopsis = new Regex("</span(.*?)<");
            int vidNumber;

            foreach (HtmlNode infoNode in infoNodes)
            {
                Match pbTitleMatches = pinkbikeTitle.Match(infoNode.OuterHtml);
                titleList.Add(pbTitleMatches.Value);

                Match pbSynopsisMatches = pinkbikeSynopsis.Match(infoNode.OuterHtml);
                synList.Add(pbSynopsisMatches.Value);
                
            }

            foreach (HtmlNode mediaNode in mediaNodes)
            {
                Match pbMatches = pinkbikeMatch.Match(mediaNode.OuterHtml);
                

                if (mediaNode.InnerHtml.Contains("pbvideo") && pbMatches.Success)
                {
                    mediaList.Add(mediaNode.InnerHtml);
                    vidNumber = mediaList.Count;

                    WebVid pbVidToAdd = new WebVid();

                    string input = pbMatches.Value;
                    string pbLink = pbPreceder + input.Substring(14, 6);
                    Console.WriteLine("PinkBike match: " + pbLink);

                    int titleLength = titleList[vidNumber].ToString().Length - 21;
                    int synopsisLength = synList[vidNumber].ToString().Length - 9;

                    pbVidToAdd.PlayerUrl = pbLink;
                    pbVidToAdd.VideoService = "PinkBike";
                    pbVidToAdd.Title = titleList[vidNumber].ToString().Substring(19, titleLength);
                    pbVidToAdd.Synopsis = synList[vidNumber].ToString().Substring(8, synopsisLength);
                    pbVidToAdd.OriginUrl = crawledPageUrl;
                    pbVidToAdd.OriginTitle = "Movies For Your Monday on PinkBike";
                    pbVidList.Add(pbVidToAdd);
                }

                else
                {
                    mediaList.Add("NOTPB");
                    //Console.WriteLine(mediaList.Count);
                    //Console.WriteLine("NOTPB");
                }
            }

            return pbVidList;
        }

        
    }
}
