using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        List<Car> GetByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetials();
        IDataResult<CarDetailDto> GetCarDetailsById(int id);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        
    }
}
