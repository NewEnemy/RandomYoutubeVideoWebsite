using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3;

namespace RandomYoutubeVideo.SideScripts
{
    public class YoutubeVideoIdGenerator
    {
        string _api;
        int _numberOfQuerrys;
        public YoutubeVideoIdGenerator(string ApiKey,int NumberOfQuerres)
        {
            _api = ApiKey;
            _numberOfQuerrys = NumberOfQuerres;
        }
    }
}
