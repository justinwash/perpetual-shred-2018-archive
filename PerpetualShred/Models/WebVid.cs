using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerpetualShred.Models
{
    public class WebVid
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PlayerUrl { get; set; }
        public string OriginUrl { get; set; }
        public string Synopsis { get; set; }
        public string VideoService { get; set; }
        public string OriginTitle { get; set; }
        public string SourceList { get; set; }
    }
}
