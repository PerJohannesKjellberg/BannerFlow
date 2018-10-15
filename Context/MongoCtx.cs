using BannerFlow.Models;
using BannerFlow.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BannerFlow.Context
{
    public class MongoCtx
    {
        private const string dbName = "BannerDb";
        public MongoDatabase db;
        protected BannerRepository<Banner> banners;

        public MongoCtx()
        {
            var connectionString = ConfigurationManager.AppSettings["MongoDB"];
            var mongoClient = new MongoClient(connectionString);
            var mongoServer = mongoClient.GetServer();
            db = mongoServer.GetDatabase(dbName);
        }

        public BannerRepository<Banner> Banners
        {
            get
            {
                if (banners == null)
                {
                    banners = new BannerRepository<Banner>(db, "banners");
                }
                return banners;
            }
        }
    }
}