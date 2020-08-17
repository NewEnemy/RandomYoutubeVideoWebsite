using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RandomYoutubeVideo.Models;

namespace RandomYoutubeVideo.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
        public DbSet<DataBaseModel> DataBaseModel { get; set; }
    }
}
