using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace RandomYoutubeVideo.Models
{
    /// <summary>
    /// Just Interface to colect Id from "Database"
    /// </summary>
    public class VideosIdModel
    {
        
        public string Video {
            get { return GetRandomVideo(); }

            set { }
        }
        List<string> VideoIds = new List<string>();
        
        public VideosIdModel()
        {
            string buffer;
            using (StreamReader reader = new StreamReader("wwwroot/tempData/YoutubeIDs.txt")) {
                
                while((buffer = reader.ReadLine()) != null)
                {
                    VideoIds.Add(buffer);
                }
                  
               
            } 


        }
        private string GetRandomVideo()
        {
            Random rand = new Random();

            return VideoIds[rand.Next(VideoIds.Count())];
        }
    }
}
