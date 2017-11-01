using System;
using HigLabo.Net.Vimeo;
using System.Net;
using Newtonsoft.Json;

namespace ShredCrawl
{
    static class VimeoInfo
    {
        static VimeoClient vmServ = Program.VimeoAuthorize();

        public static VimeoVid RetrieveData(string vidUrl)
        {
            int vidID = Int32.Parse(vidUrl);
            VimeoVid vmVid = new VimeoVid();
            string channelTitle = "MISSING";
            

            WebClient myDownloader = new WebClient();
            myDownloader.Encoding = System.Text.Encoding.UTF8;

            string jsonResponse = myDownloader.DownloadString("http://vimeo.com/api/v2/video/" + vidID + ".json");
            
            var item = JsonConvert.DeserializeObject(jsonResponse);

            vmVid.ChannelTitle = channelTitle;
            //vmVid.ChannelID = item.url;
            //vmVid.Title = item.title;
            //vmVid.ReleaseDate = Convert.ToDateTime(item.upload_date);
            //vmVid.Synopsis = item.description;
            return vmVid;
        }

        public static string vmTruncate(this string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
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

