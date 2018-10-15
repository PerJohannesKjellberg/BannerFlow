using BannerFlow.Context;
using BannerFlow.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BannerFlow.Services
{
    public class BannerService : IBannerService
    {
        private readonly MongoCtx mongoCtx;
        public BannerService()
        {
            mongoCtx = new MongoCtx();
        }
        public void Create(Banner banner)
        {
            mongoCtx.Banners.Add(banner);
        }
        public Banner Get(int id)
        {
            return mongoCtx.Banners.Get(id);
        }
        public void Update(Banner banner)
        {
            mongoCtx.Banners.Update(b => b.Id, banner.Id, banner);
        }
        public void Delete(int id)
        {
            mongoCtx.Banners.Delete(b => b.Id, id);
        }
    }
}