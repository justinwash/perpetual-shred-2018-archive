using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace ShredCrawl
{
    internal class PinkBikeCollection
    {
        public static IEnumerable<WebVid> Collect(HtmlDocument htmlDoc, string originUrl)
        {
            var pinkbikeMatch = new Regex("(data-videoid=\")([0-9]+)\"");
            var pbVidList = new List<WebVid>();
            var titleList = new ArrayList();
            var thumbList = new ArrayList();
            var synList = new ArrayList();
            var mediaList = new ArrayList();
            var infoNodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'blog-text-container')]");
            var mediaNodes = htmlDoc.DocumentNode.SelectNodes("//div[contains(@class, 'blog-media-container')]");
            var pageTitle = htmlDoc.DocumentNode.SelectSingleNode("//title");

            var pinkbikeTitle = new Regex("<span(.*?)<");
            var pinkbikeSynopsis = new Regex("</span(.*?)<");
            var videoSource = new Regex("<source(.*?)type");
            var pinkbikeThumb = new Regex("poster(.*?).jpg");
            int vidNumber;

            var pbPreceder = "www.pinkbike.com/v/embed/";

            if (infoNodes == null)
            {
                return new List<WebVid>();
            }

            foreach (var infoNode in infoNodes)
            {
                var pbTitleMatches = pinkbikeTitle.Match(infoNode.OuterHtml);
                titleList.Add(pbTitleMatches.Value);

                var pbSynopsisMatches = pinkbikeSynopsis.Match(infoNode.InnerHtml);
                synList.Add(pbSynopsisMatches.Value);

            }

            foreach (var mediaNode in mediaNodes)
            {
                var pbMatches = pinkbikeMatch.Match(mediaNode.OuterHtml);


                if (mediaNode.InnerHtml.Contains("pbvideo") && pbMatches.Success)
                {
                    var pbSourceList = new List<string>();
                    var sourceMatches = videoSource.Matches(mediaNode.OuterHtml);
                    mediaList.Add(mediaNode.InnerHtml);
                    vidNumber = mediaList.Count - 1;

                    var pbVidToAdd = new WebVid();

                    var input = pbMatches.Value;
                    var pbLink = pbPreceder + input.Substring(14, 6);
                    Console.WriteLine(@"PinkBike match: " + pbLink);

                    var titleLength = titleList[vidNumber].ToString().Length - 21;
                    var synopsisLength = synList[vidNumber].ToString().Length - 8;

                    pbVidToAdd.PlayerUrl = "https://" + pbLink + "?colors=c80000&a=1&showheadshot=0&showtitle=0&showbyline=0";
                    pbVidToAdd.VideoService = "PinkBike";

                    var pbThumb = pinkbikeThumb.Match(mediaNode.InnerHtml).Value;
                    pbVidToAdd.Thumbnail = pbThumb.Substring(8, (pbThumb.Length - 8));

                    if ((titleList[vidNumber].ToString() != null) && (titleList[vidNumber].ToString() != ""))
                    {
                        pbVidToAdd.Title = titleList[vidNumber].ToString().Substring(19, titleLength);
                    }
                    if ((synList[vidNumber].ToString() != null) && (synList[vidNumber].ToString() != ""))
                    {
                        pbVidToAdd.Synopsis = synList[vidNumber].ToString().Substring(7, synopsisLength);
                    }
                    pbVidToAdd.OriginUrl = originUrl;
                    pbVidToAdd.OriginTitle = pageTitle.InnerText;
                    pbVidToAdd.ReleaseDate = DateTime.Today;

                    foreach (Match foundSource in sourceMatches)
                    {
                        var truncatedSourceFirstPass = foundSource.Value.Substring(33);
                        pbSourceList.Add(truncatedSourceFirstPass);
                    }

                    
                    if (pbSourceList.Count > 0)
                    {
                        var incr = 0;
                        while (incr <= pbSourceList.Count - 1)
                        {
                            if (incr == 3)
                                pbSourceList[incr] = pbSourceList[incr].Substring(1, (pbSourceList[incr].Length - 7));
                            else
                                pbSourceList[incr] = pbSourceList[incr].Substring(0, (pbSourceList[incr].Length - 6));
                            incr++;
                        }
                    }
                    else
                    {
                        mediaList.Add("NOTPB");
                    }
                    
                    

                    if (pbSourceList.Count < 1) continue;
                    var sourcesJson = JsonConvert.SerializeObject(pbSourceList);
                    Console.WriteLine(@"sourceList= " + JsonConvert.DeserializeObject(sourcesJson));
                    pbVidToAdd.SourceList = sourcesJson;
                    pbVidList.Add(pbVidToAdd);
                }

                else
                {
                    mediaList.Add("NOTPB");
                }
            }

            return pbVidList;
        }
        }
}
