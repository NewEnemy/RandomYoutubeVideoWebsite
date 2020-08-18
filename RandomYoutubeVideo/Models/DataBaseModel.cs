using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RandomYoutubeVideo.Models
{
    public class DataBaseModel
    {

        public int Id { get; set; }
        public string VidId { get; set; }
        public int Views { get; set; }
        public double Rating { get; set; }
    }
}
