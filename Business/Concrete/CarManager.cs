using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.NLog;
using Core.CrossCuttingConcerns.Logging.NLog.Loggers;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;



        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id), CarConstants.CarGettedById);
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetials()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails());
        }

        public IDataResult<CarDetailDto> GetCarDetailsById(int id)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarsDetails(c=>c.Id==id).FirstOrDefault());
        }

        //[ValidationAspect(typeof(CarValidator))]
        //[SecuredOperation("admin,moderator")]
        //[CacheRemoveAspect("ICarService.Get")]

        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarCountOfBrandCorrect(car.BrandId), CheckIfCarNameExists(car.CarName));
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);

            return new SuccessResult(CarConstants.CarAdded);
        }
        [SecuredOperation("admin,moderator")]
        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("admin,moderator")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(CarConstants.CarDeleted);
        }
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin,moderator")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(CarConstants.CarUpdated);
        }


        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), CarConstants.AllCarGetted);
        }

        #region BusinessRules

        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result >= 15)
            {
                return new ErrorResult("brand sınırı aşıldı");
            }

            return new SuccessResult();
        }

        private IResult CheckIfCarNameExists(string carName)
        {
            if (_carDal.GetAll(c => c.CarName == carName).Any())
            {
                return new ErrorResult("Aynı isimde araç var");
            }

            return new SuccessResult();
        }


        #endregion


    }
}
