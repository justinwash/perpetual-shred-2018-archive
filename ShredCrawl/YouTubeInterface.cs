using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.Text.RegularExpressions;

namespace ShredCrawl
{
    static class YouTubeInterface
    {
        static YouTubeService ytServ = Program.YoutTubeAuthorize();

        public static YouTubeVid RetrieveData(string vidID)
        {
            YouTubeVid ytVid = new YouTubeVid();
            string title = null;
            DateTime? releaseDate = null;
            string synopsis = null;
            string channelTitle = null;
            string channelID = null;

            var request = ytServ.Videos.List("snippet");

            request.Id = vidID;
            var response = request.Execute();
            if (response.Items.Count == 1)
            {
                Video video = response.Items[0];
                title = video.Snippet.Title;
                releaseDate = video.Snippet.PublishedAt;
                synopsis = video.Snippet.Description.ytTruncate(200);
                channelTitle = video.Snippet.ChannelTitle;
                channelID = video.Snippet.ChannelId;
            }

            ytVid.ChannelTitle = channelTitle;
            ytVid.ChannelID = channelID;
            ytVid.Title = title;
            ytVid.ReleaseDate = releaseDate;
            ytVid.Synopsis = synopsis;
            return ytVid;
        }
            public static List<WebVid> YouTubeCollect(HtmlDocument htmlDoc)
            {
                Regex youtubeMatch = new Regex("youtu(?:.be|be.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]).+?(?=\")");
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

                        YouTubeVid tempVid = YouTubeInterface.RetrieveData(ytID);

                        Console.WriteLine("Youtube match: " + input);

                        ytVidToAdd.Title = tempVid.Title;
                        ytVidToAdd.ReleaseDate = tempVid.ReleaseDate;
                        ytVidToAdd.Synopsis = tempVid.Synopsis;
                        ytVidToAdd.PlayerUrl = "http://www." + input + "?rel=0&autoplay=1&amp;showinfo=0";
                        ytVidToAdd.OriginUrl = "http://www.youtube.com/channel/" + tempVid.ChannelID;
                        ytVidToAdd.OriginTitle = tempVid.ChannelTitle + " on YouTube";
                        ytVidToAdd.VideoService = "YouTube";
                        ytVidList.Add(ytVidToAdd);

                    }
                }

                return ytVidList;
            }

        public static string ytTruncate(this string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }
    }

    class YouTubeSettings
    {
        public static string apiKey = "AIzaSyBV0CufWBbF7O1J6Y27kw5Tmmbcwj5t1Ho";
        public static string appName = "PerpetualShred";
    }
}
