using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;

namespace ShredCrawl
{
    public interface IVideoCollection
    {
        IEnumerable<WebVid> Collect(HtmlDocument html);
    }
}
