using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ShredCrawl
{
    class PinkBikeInterface
    {
        public static List<WebVid> PinkBikeCollect(HtmlDocument htmlDoc)
        {
            Regex pinkbikeMatch = new Regex("(data-videoid=\")([0-9]+)\"");
            string crawledPageUrl = "http://www.pinkbike.com"; //CHANGE THIS WHEN THE CRAWLER ACTUALLY CRAWLS
            var pbVidList = new List<WebVid>();
            var titleList = new ArrayList();
            var synList = new ArrayList();
            var mediaList = new ArrayList();
            var infoNodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'blog-text-container')]");
            var mediaNodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'blog-media-container')]");

            Regex pinkbikeTitle = new Regex("<span(.*?)<");
            Regex pinkbikeSynopsis = new Regex("</span(.*?)<");
            int vidNumber;

            string pbPreceder = "www.pinkbike.com/v/embed/";

            if (infoNodes == null)
            {
                return new List<WebVid>();
            }

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
                    vidNumber = mediaList.Count - 1;

                    WebVid pbVidToAdd = new WebVid();

                    string input = pbMatches.Value;
                    string pbLink = pbPreceder + input.Substring(14, 6);
                    Console.WriteLine("PinkBike match: " + pbLink);

                    int titleLength = titleList[vidNumber].ToString().Length - 21;
                    int synopsisLength = synList[vidNumber].ToString().Length - 9;

                    pbVidToAdd.PlayerUrl = "https://" + pbLink + "/?colors=c80000&a=1";
                    pbVidToAdd.VideoService = "PinkBike";
                  //  pbVidToAdd.Title = titleList[vidNumber].ToString().Substring(19, titleLength);
                  //  pbVidToAdd.Synopsis = synList[vidNumber].ToString().Substring(8, synopsisLength);
                    pbVidToAdd.OriginUrl = crawledPageUrl;
                    pbVidToAdd.OriginTitle = "Movies For Your Monday on PinkBike";
                    pbVidToAdd.ReleaseDate = DateTime.Today;
                    pbVidList.Add(pbVidToAdd);
                }

                else
                {
                    mediaList.Add("NOTPB");
                }
            }

            return pbVidList;
        }
        }
}
