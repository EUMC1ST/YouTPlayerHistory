using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouTPlayerHistory.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public string VideoId { get; set; }
    }
}