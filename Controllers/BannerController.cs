using BannerFlow.Models;
using BannerFlow.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BannerFlow.Controllers
{
    //[RoutePrefix("api/banners")]
    public class BannerController : ApiController
    {
        private readonly IBannerService bannerService;
        public BannerController()
        {
            bannerService = new BannerService();
        }

        public HttpResponseMessage Get(int id)
        {
            var banner = bannerService.Get(id);
            if (banner != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, banner);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Banner withe id={0} not found.", id.ToString()));
        }

        public void Post([FromBody]Banner banner)
        {
            bannerService.Create(banner);
        }
        public void Delete(int id)
        {
            bannerService.Delete(id);
        }
        public void Put([FromBody]Banner banner)
        {
            bannerService.Update(banner);
        }
    }
}
