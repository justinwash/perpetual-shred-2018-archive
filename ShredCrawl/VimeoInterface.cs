using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace ShredCrawl
{
    internal static class VimeoInterface
    {
        private static VimeoVid RetrieveData(string vidUrl)
        {
            var vidId = int.Parse(vidUrl);
            var vmVid = new VimeoVid();

            var myDownloader = new WebClient {Encoding = Encoding.UTF8};


            var jsonResponse = myDownloader.DownloadString("http://vimeo.com/api/v2/video/" + vidId + ".json");
            var tempVidList = JsonConvert.DeserializeObject<List<VimeoVid>>(jsonResponse);
            var tempVid = tempVidList[0];

            vmVid.Title = tempVid.Title;
            vmVid.UserId = tempVid.UserId;
            vmVid.UserName = tempVid.UserName;
            vmVid.UploadDate = tempVid.UploadDate;
            vmVid.Description = VmTruncate(tempVid.Description, 200);
            vmVid.ThumbnailLarge = tempVid.ThumbnailLarge;
            return vmVid;
        }

        private static string VmTruncate(this string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }

        public static IEnumerable<WebVid> VimeoCollect(HtmlDocument htmlDoc)
        {
            var vimeoMatch = new Regex("(player.)?(vimeo.com)/(video/)?([0-9]+)");

            var vmVidList = new List<WebVid>();
            var vmNodes = htmlDoc.DocumentNode.SelectNodes("//iframe");

            if (vmNodes == null)
            {
                return new List<WebVid>();
            }

            foreach (var node in vmNodes)
            {
                var vimeoMatches = vimeoMatch.Match(node.OuterHtml);

                if (!vimeoMatches.Success) continue;
                var vmVidToAdd = new WebVid();

                var input = vimeoMatches.Value;

<<<<<<< HEAD
                var vmId = input.Substring(23, input.Length == 32 ? 9 : 8);
=======
                var vmId = input.Substring(23, input.Length - 23);
>>>>>>> origin/master

                Console.WriteLine(@"Vimeo match: " + input);

                var tempVid = RetrieveData(vmId);

                vmVidToAdd.Title = tempVid.Title;
                vmVidToAdd.ReleaseDate = Convert.ToDateTime(tempVid.UploadDate);
                vmVidToAdd.Synopsis = tempVid.Description;
                vmVidToAdd.PlayerUrl = "https://" + input + "?autoplay=1";
                vmVidToAdd.OriginUrl = "http://www.vimeo.com/" + tempVid.UserId;
                vmVidToAdd.OriginTitle = tempVid.UserName + " on Vimeo";
                vmVidToAdd.VideoService = "Vimeo";
                vmVidToAdd.Thumbnail = tempVid.ThumbnailLarge;
                vmVidList.Add(vmVidToAdd);
            }

            return vmVidList;
        }

    }

    internal class VimeoSettings
    {
        public static string ConsumerKey = "2d70dbab78ddc882a591aae3d9fb2c73b34ecb87";
        public static string ConsumerSecret = "65HlFHS2vGqK/7cwvi+UXreW3y2soqAnQldlETLqObXISJi8dWnspIHVPy3icgW86YRbmicGFBFaNrLVYEe+GojmE4xoCQgPnP0B7+Ege0N8K9Mhj/eHaGV8PpOgIAdd";
        public static string AccessToken = "b46b1584882016759bc8b65e8a08cb58";
        public static string AccessTokenSecret = "";
    }

    

}

