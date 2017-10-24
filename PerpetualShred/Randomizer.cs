using PerpetualShred.Models;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PerpetualShred
{
    public class Randomizer : Controller
    {
        static string previousVid;

        public static int RandomVidPicker(List<WebVid> vidList)
        {
            int id;
            WebVid vidToPlay;
            
            vidToPlay = vidList[(new Random().Next(0, vidList.Count))];
            id = vidToPlay.ID;
            previousVid = JsonConvert.SerializeObject(vidToPlay);
            //WriteCookie("PreviousVid", previousVid);

            return id;
        }
    }
}
