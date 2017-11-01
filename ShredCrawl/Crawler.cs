﻿using System;
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

        static HtmlWeb web;
        static HtmlDocument htmlDoc;

        public static void Crawl(string crawlTarget)
        {
            web = new HtmlWeb();
            htmlDoc = web.Load(crawlTarget);
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

                    vmVidToAdd.Title = tempVid.Title;
                    vmVidToAdd.ReleaseDate = tempVid.ReleaseDate;
                    vmVidToAdd.Synopsis = tempVid.Synopsis;
                    vmVidToAdd.PlayerUrl = input;
                    vmVidToAdd.OriginUrl = "http://www.vimeo.com/" + tempVid.ChannelID;
                    vmVidToAdd.OriginTitle = tempVid.ChannelTitle + " on YouTube";
                    vmVidToAdd.VideoService = "Vimeo";
                    vmVidList.Add(vmVidToAdd);

                }
            }

            return vmVidList;
        }

        public static List<WebVid> PinkBikeCollect()
        {
            var pbVidList = new List<WebVid>();
            var pbNodes = htmlDoc.DocumentNode.SelectNodes("//video");

            foreach (HtmlNode node in pbNodes)
            {
                Match pbMatches = pinkbikeMatch.Match(node.OuterHtml);
                //var infoNode = node.SelectNodes("//div/");
                //Regex findTitle = new Regex("(data-videoid=\")([0-9]+)\"");
                if (pbMatches.Success)
                {
                    WebVid pbVidToAdd = new WebVid();

                    string input = pbMatches.Value;
                    string pbLink = pbPreceder + input.Substring(14, 6);
                    Console.WriteLine("PinkBike match: " + pbLink);

                    pbVidToAdd.PlayerUrl = pbLink;
                    pbVidToAdd.VideoService = "PinkBike";
                    pbVidList.Add(pbVidToAdd);
                }
            }

            return pbVidList;
        }

        
    }
}
