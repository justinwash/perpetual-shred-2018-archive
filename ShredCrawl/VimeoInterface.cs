using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace ShredCrawl
{
    static class VimeoInterface
    {

        public static VimeoVid RetrieveData(string vidUrl)
        {
            int vidID = Int32.Parse(vidUrl);
            VimeoVid vmVid = new VimeoVid();
           
            WebClient myDownloader = new WebClient();
            myDownloader.Encoding = System.Text.Encoding.UTF8;


            string jsonResponse = myDownloader.DownloadString("http://vimeo.com/api/v2/video/" + vidID + ".json");
            List<VimeoVid> tempVidList = JsonConvert.DeserializeObject<List<VimeoVid>>(jsonResponse);
            var tempVid = tempVidList[0];

            vmVid.title = tempVid.title;
            vmVid.user_id = tempVid.user_id;
            vmVid.user_name = tempVid.user_name;
            vmVid.upload_date = tempVid.upload_date;
            vmVid.description = vmTruncate(tempVid.description, 200);
            return vmVid;
        }

        public static string vmTruncate(this string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }

        public static List<WebVid> VimeoCollect(HtmlDocument htmlDoc)
        {
            Regex vimeoMatch = new Regex("(player.)?(vimeo.com)/(video/)?([0-9]+)");

            var vmVidList = new List<WebVid>();
            var vmNodes = htmlDoc.DocumentNode.SelectNodes("//iframe");

            if (vmNodes == null)
            {
                return new List<WebVid>();
            }

            foreach (HtmlNode node in vmNodes)
            {
                Match vimeoMatches = vimeoMatch.Match(node.OuterHtml);

                if (vimeoMatches.Success)
                {
                    WebVid vmVidToAdd = new WebVid();
                    string vmID = "";

                    string input = vimeoMatches.Value;

                    if (input.Length == 32)
                    {
                        vmID = input.Substring(23, 9);
                    }
                    else
                    {
                        vmID = input.Substring(23, 8);
                    }

                    Console.WriteLine("Vimeo match: " + input + "?autoplay=1");

                    VimeoVid tempVid = VimeoInterface.RetrieveData(vmID);

                    vmVidToAdd.Title = tempVid.title;
                    vmVidToAdd.ReleaseDate = Convert.ToDateTime(tempVid.upload_date);
                    vmVidToAdd.Synopsis = tempVid.description;
                    vmVidToAdd.PlayerUrl = "https://" + input + "autoplay=1";
                    vmVidToAdd.OriginUrl = "http://www.vimeo.com/" + tempVid.user_id;
                    vmVidToAdd.OriginTitle = tempVid.user_name + " on Vimeo";
                    vmVidToAdd.VideoService = "Vimeo";
                    vmVidList.Add(vmVidToAdd);

                }
            }

            return vmVidList;
        }

    }

    class VimeoSettings
    {
        public static string ConsumerKey = "2d70dbab78ddc882a591aae3d9fb2c73b34ecb87";
        public static string ConsumerSecret = "65HlFHS2vGqK/7cwvi+UXreW3y2soqAnQldlETLqObXISJi8dWnspIHVPy3icgW86YRbmicGFBFaNrLVYEe+GojmE4xoCQgPnP0B7+Ege0N8K9Mhj/eHaGV8PpOgIAdd";
        public static string AccessToken = "b46b1584882016759bc8b65e8a08cb58";
        public static string AccessTokenSecret = "";
    }

    

}

