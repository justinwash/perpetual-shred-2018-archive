using System;
using System.Collections.Generic;
using System.Text;

using BlackBayou.Vimeo.Api;
using BlackBayou.Vimeo.Api.Videos;
using BlackBayou.Vimeo.OAuth;

namespace ShredCrawl
{
    static class VimeoInfo
    {
        static VimeoService vmServ = Program.VimeoAuth();

        public static VimeoVid RetrieveData(string vidID)
        {
            int vidNumber = Int32.Parse(vidID);
            VimeoVid vmVid = new VimeoVid();
            string title = null;
            DateTime? releaseDate = null;
            string synopsis = null;
            string channelTitle = null;
            string channelID = null;

            vmServ.apiClient.Videos.GetVideoInfo(vidNumber);

            vmVid.ChannelTitle = channelTitle;
            vmVid.ChannelID = channelID;
            vmVid.Title = title;
            vmVid.ReleaseDate = releaseDate;
            vmVid.Synopsis = synopsis;
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

    class VimeoService
    {
        public InMemoryTokenManager tokenManager { get; set; }
        public VimeoPlusApi apiClient { get; set; }
    }

}

