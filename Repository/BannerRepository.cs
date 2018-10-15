using BannerFlow.Models;
using BannerFlow.Templates;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Hosting;

namespace BannerFlow.Repository
{
    public class BannerRepository<T> where T : class
    {
        private MongoDatabase database;
        private string _tableName;
        private MongoCollection<T> _collection;
        private string _htmlTemplate;
        public BannerRepository(MongoDatabase mongoDatabase, string tblName)
        {
            database = mongoDatabase;
            _tableName = tblName;
            _collection = database.GetCollection<T>(tblName);
            _htmlTemplate = ConfigurationManager.AppSettings["HtmlTemplate"];

        }

        public void Add(T entity)
        {
            var banner = entity as Banner;
            if(banner == null)
            {
                return;
            }

            banner.Html = CreateHtml(banner);

            _collection.Insert(banner);
        }

        public T Get(int id)
        {
            return _collection.FindOneById(id);
        }

        public void Delete(Expression<Func<T, int>> queryExpression, int id)
        {
            var query = Query<T>.EQ(queryExpression, id);
            _collection.Remove(query);
        }

        public void Update(Expression<Func<T, int>> queryExpression, int id, T entity)
        {
            var banner = entity as Banner;
            banner.Html = CreateHtml(banner);

            var query = Query<T>.EQ(queryExpression, id);
            _collection.Update(query, Update<T>.Replace(banner as T));
        }

        private string CreateHtml(Banner banner)
        {
            var templatePath = HostingEnvironment.MapPath("/" + _htmlTemplate);
            var template = new HtmlTemplate(templatePath);
            return template.Render(new
            {
                TITLE = string.Format("Banner {0}", banner.Id),
                BODY = banner.Html,
            });
        }
    }
}