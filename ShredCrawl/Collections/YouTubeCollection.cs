using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using HtmlAgilityPack;

namespace ShredCrawl
{
    public class YouTubeCollection : IVideoCollection
    {

        public IEnumerable<WebVid> Collect(HtmlDocument htmlDoc)
        {
            var youtubeMatch = new Regex("youtu(?:.be|be.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]).+?(?=\")");
            var ytVidList = new List<WebVid>();
            var ytNodes = htmlDoc.DocumentNode.SelectNodes("//iframe");

            if (ytNodes == null)
            {
                return new List<WebVid>();
            }

            foreach (var node in ytNodes)
            {
                var youtubeMatches = youtubeMatch.Match(node.OuterHtml);

                if (!youtubeMatches.Success) continue;
                var ytVidToAdd = new WebVid();

                var input = youtubeMatches.Value;
                var ytId = input.Substring(18, 11);

                var tempVid = RetrieveData(ytId);

                Console.WriteLine(@"Youtube match: " + input);

                ytVidToAdd.Title = tempVid.Title;
                ytVidToAdd.ReleaseDate = tempVid.ReleaseDate;
                ytVidToAdd.Synopsis = tempVid.Synopsis;
                ytVidToAdd.PlayerUrl = "http://www." + input + "?&theme=dark&autoplay=1&autohide=1&modestbranding=1&fs=0&showinfo=0&rel=0";
                ytVidToAdd.OriginUrl = "http://www.youtube.com/channel/" + tempVid.ChannelId;
                ytVidToAdd.OriginTitle = tempVid.ChannelTitle + " on YouTube";
                ytVidToAdd.VideoService = "YouTube";
                ytVidToAdd.Thumbnail = tempVid.Thumbnail;
                ytVidList.Add(ytVidToAdd);
            }

            return ytVidList;
        }
        private YouTubeVid RetrieveData(string vidId)
        {

            var ytVid = new YouTubeVid();
            string title = null;
            DateTime? releaseDate = null;
            string synopsis = null;
            string channelTitle = null;
            string channelId = null;

            var ytserv = YoutTubeAuthorize();
            var request = ytserv.Videos.List("snippet");

            request.Id = vidId;
            var response = request.Execute();
            if (response.Items.Count == 1)
            {
                var video = response.Items[0];
                title = video.Snippet.Title;
                releaseDate = video.Snippet.PublishedAt;
                synopsis = YtTruncate(video.Snippet.Description, 200);
                channelTitle = video.Snippet.ChannelTitle;
                channelId = video.Snippet.ChannelId;
            }

            ytVid.ChannelTitle = channelTitle;
            ytVid.ChannelId = channelId;
            ytVid.Title = title;
            ytVid.ReleaseDate = releaseDate;
            ytVid.Synopsis = synopsis;
            ytVid.Thumbnail = "https://img.youtube.com/vi/" + vidId + "/maxresdefault.jpg";
            return ytVid;
        }

        private string YtTruncate(string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }

        private YouTubeService YoutTubeAuthorize()
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = YouTubeSettings.ApiKey,
                ApplicationName = YouTubeSettings.AppName
            });

            return youtubeService;
        }
    }

    internal static class YouTubeSettings
    {
        public const string ApiKey = "AIzaSyBV0CufWBbF7O1J6Y27kw5Tmmbcwj5t1Ho";
        public const string AppName = "PerpetualShred";
    }
}
