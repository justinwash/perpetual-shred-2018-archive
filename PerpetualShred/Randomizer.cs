using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PerpetualShred.Models;

namespace PerpetualShred
{
    public class Randomizer : Controller
    {
        private static string _previousVid;

        public Randomizer()
        {
            
        }

        public int RandomVidPicker(List<WebVid> vidList)
        {
            if (vidList.Count <= 0) return -1;
            int id;
            WebVid vidToPlay;
            List<string> unwatchedIds = null;
            vidToPlay = vidList[(new Random().Next(0, vidList.Count))];
            id = vidToPlay.Id;
            _previousVid = JsonConvert.SerializeObject(vidToPlay);

            return id;
        }
    }
}
