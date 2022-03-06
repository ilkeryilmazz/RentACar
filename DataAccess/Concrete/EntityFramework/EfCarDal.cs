using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                

                var result = from c in context.Cars
                    join co in context.Colors on c.ColorId equals co.Id
                    join b in context.Brands on c.BrandId equals b.Id 
                    
                    select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.Name,
                                 CarName = c.CarName,
                                 ColorName = co.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 Images =  (from image in context.CarImages where c.Id == image.CarId  select new CarImageDetailDto { ImagePath = image.ImagePath }).ToList()
                    };
             

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }

        }
    }
}
