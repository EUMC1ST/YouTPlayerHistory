using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace YouTPlayerHistory.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public AppDbContext() : base("name=Model")
        {
            

        }
    }
}