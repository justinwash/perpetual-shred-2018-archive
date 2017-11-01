using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ShredCrawl
{
    static class VimeoInfo
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

        
        
    }

    class VimeoSettings
    {
        public static string ConsumerKey = "2d70dbab78ddc882a591aae3d9fb2c73b34ecb87";
        public static string ConsumerSecret = "65HlFHS2vGqK/7cwvi+UXreW3y2soqAnQldlETLqObXISJi8dWnspIHVPy3icgW86YRbmicGFBFaNrLVYEe+GojmE4xoCQgPnP0B7+Ege0N8K9Mhj/eHaGV8PpOgIAdd";
        public static string AccessToken = "b46b1584882016759bc8b65e8a08cb58";
        public static string AccessTokenSecret = "";
    }

    

}

