using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.UI.HtmlControls;
using YouTPlayerHistory.Models;

namespace YouTPlayerHistory.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VideosController : ApiController
    {
        public AppDbContext Context;
        public VideosController()
        {
            Context = new AppDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            Context.Dispose();
        }

        public IEnumerable<Video> GetVideos()
        {
            return Context.Videos.ToList();
        }

        [HttpGet]
        public Video GetVideo(string videoId)
        {
            Video videoDB = Context.Videos.FirstOrDefault<Video>(v => v.VideoId == videoId);
            if (videoDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return videoDB;
        }
        [HttpPost]
        //public IHttpActionResult CreateVideo([FromBody] Video video)
        public IEnumerable<Video> CreateVideo([FromBody] Video video)
        {
            if (!ModelState.IsValid)
            {
                throw  new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var videoDb = Context.Videos.FirstOrDefault(v=> v.VideoId == video.VideoId);
            if (videoDb != null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Accepted));
            }
            var videoAdded = Context.Videos.Add(video);
            Context.SaveChanges();
            //return Created(Request.RequestUri + "/" + videoAdded.VideoId, videoAdded);
            return Context.Videos.ToList();
        }

        //[HttpPut]
        //public Video UpdateVideo(Video video)
        //{
        //    Video videoDb = Context.Videos.FirstOrDefault(v => v.Id == video.Id);
        //    if (videoDb != null)
        //    {
        //        Video videoModel = new Video()
        //        {
        //            Id = videoDb.Id
        //        };
        //    }
        //    return  ;
        //}
    }
}
