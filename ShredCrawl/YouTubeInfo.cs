using System;
using System.Collections.Generic;
using System.Text;

using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace ShredCrawl
{
    static class YouTubeInfo
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
