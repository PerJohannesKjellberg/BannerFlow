using BannerFlow.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BannerFlow.Services
{
    public interface IBannerService
    {
        void Create(Banner banner);
        Banner Get(int id);
        void Update(Banner banner);
        void Delete(int id);

    }
}
