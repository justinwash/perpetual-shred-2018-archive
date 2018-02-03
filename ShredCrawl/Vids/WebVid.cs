using System;

namespace ShredCrawl
{
    public class WebVid
    {
        public int Id { get; set; }
        public string OriginUrl { get; set; } 
        public string PlayerUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Synopsis { get; set; }
        public string Title { get; set; }
        public string VideoService { get; set; }
        public string OriginTitle { get; set; }
        public string SourceList { get; set; }
        public string Thumbnail { get; set; }
    }
}
