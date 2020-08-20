using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft;
using System.IO;
using System.Web.Helpers;

namespace RandomYoutubeVideo.SideScripts
{
    public class RandomWordsGenerator
    {
        string Wordslist = @"tempData\WordsList.txt";
        Random rand;
        int totalWords = 0;
        public RandomWordsGenerator()
        {
            rand = new Random();
            ////Just to get total words count
            using(var reader = new StreamReader(Wordslist))
            {
                var json = new JsonTextReader(reader);
                while (json.Read())
                {
                    if (json.TokenType == JsonToken.String)
                    {
                        totalWords++;
                    }
                }
            }

        }
        public string Next()
        {
            int counter = 0;
            using(var reader = new StreamReader(Wordslist))
            {
                var json = new JsonTextReader(reader);
                
                while (json.Read())
                {
                    if(json.TokenType == JsonToken.String)
                    {
                        counter++;
                        if(rand.Next(totalWords) <= counter)
                        {
                            return (string)json.Value;
                        }
                    }
                   
                }
            }
            return "null";
        }
    }
}
