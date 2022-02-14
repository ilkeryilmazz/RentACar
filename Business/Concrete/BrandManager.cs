using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        private IBrandDal _brandDal;
        private ICarService _carService;

        public BrandManager(IBrandDal brandDal, ICarService carService)
        {
            _brandDal = brandDal;
            _carService = carService;
        }
        [ValidationAspect(typeof(BrandValidator))]
        [SecuredOperation("admin,moderator")]
        public IResult Add(Brand brand)
        {
            var result = BusinessRules.Run(CheckBrandCountIfGreaterThen5(),CheckBrandNameExists(brand.Name));
            if (result!=null)
            {
                return result;
            }
            _brandDal.Add(brand);
            return new SuccessResult(BrandConstants.BrandAdded);
        }
        [SecuredOperation("admin,moderator")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(BrandConstants.BrandDeleted);
        }
        [ValidationAspect(typeof(BrandValidator))]
        [SecuredOperation("admin,moderator")]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(BrandConstants.BrandUpdated);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),BrandConstants.AllBrandGetted);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.Id==id),BrandConstants.BrandGettedById);
        }

        #region BusinessRules

        private IResult CheckBrandCountIfGreaterThen5()
        {
            var result = _brandDal.GetAll().Count;
            if (result>=5)
            {
                return new ErrorResult(BrandConstants.MaximumBrandLimitExceeded);
            }

            return new SuccessResult();
        }
        private IResult CheckBrandNameExists(string brandName)
        {
            var result = _brandDal.GetAll(b=>b.Name==brandName).Any();
            if (result)
            {
                new ErrorResult(BrandConstants.BrandNameExists);
            }

            return new SuccessResult();
        }

        private IResult CheckBrandIsHaveCar(int brandId)
        {

            var result = _carService.GetByBrandId(brandId).Any();
            if (result)
            {
                return new ErrorResult(BrandConstants.BrandIsHaveCarCantDeleted);
            }

            return new SuccessResult();
        }
        #endregion
    }
}
