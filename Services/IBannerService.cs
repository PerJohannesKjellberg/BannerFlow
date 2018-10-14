using BannerFlow.Models;
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
        Banner Get(int i);
        //IQueryable<Banner> GetAll();
        void Update(Banner student);
        void Delete(int id);

    }
}
