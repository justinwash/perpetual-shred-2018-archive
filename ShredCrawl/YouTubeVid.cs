using System;
using System.Collections.Generic;

namespace ShredCrawl
{
    public partial class YouTubeVid
    {
        public DateTime? ReleaseDate { get; set; }
        public string Synopsis { get; set; }
        public string Title { get; set; }
        public string ChannelTitle { get; set; }
        public string ChannelID { get; set; }
    }
}
