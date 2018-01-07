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
        private ICookieService _cookieService;

        public Randomizer(ICookieService cookieService)
        {
            _cookieService = cookieService;
        }

        public int RandomVidPicker(List<WebVid> vidList)
        {
            if (vidList.Count > 0)
            {
                int id;
                WebVid vidToPlay;
                List<string> unwatchedIds = null;

                var unwatchedCookie = _cookieService.GetCookie("randomVideoUnwatched");
                if (string.IsNullOrWhiteSpace(unwatchedCookie))
                {
                    var randomVideoUnwatchedValue = string.Join(';', (from v in vidList
                                                                         select v.Id));
                    //_cookieService.CreateCookie("randomVideoUnwatched", randomVideoUnwatchedValue);
                }
                else
                {
                    unwatchedIds = unwatchedCookie.Split(';').ToList();
                }

                if (unwatchedIds == null)
                {
                    vidToPlay = vidList[(new Random().Next(0, vidList.Count))];
                }
                else
                {
                    var selectedVidDbId = Int32.Parse(unwatchedIds[(new Random().Next(0, unwatchedIds.Count))]);
                    var selectedVidAdaptedId = selectedVidDbId - Int32.Parse(unwatchedIds[0]);
                    vidToPlay = vidList[selectedVidAdaptedId];
                }
                
                id = vidToPlay.Id;
                _previousVid = JsonConvert.SerializeObject(vidToPlay);

                return id;
            }
            return -1;
        }
    }
}
