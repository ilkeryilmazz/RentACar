using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager:ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [TransactionScopeAspect]
        [ValidationAspect(typeof(CarImageValidator))]
     
        public IResult Add(IFormFile file, CarImage carImage)
        {
            
          
            var result= BusinessRules.Run(CheckCarImagesLimit(carImage.CarId));

           if (result!=null)
           {
               return new ErrorResult(result.Message);
           }
           carImage.ImagePath = FileHelper.Upload(file, PathConstants.ImagesPath);
            _carImageDal.Add(carImage);


            return new SuccessResult(CarImageConstants.CarImagesAdded);
        }
        [ValidationAspect(typeof(CarImageValidator))]
        [SecuredOperation("admin,moderator")]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            FileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult(CarImageConstants.CarImagesUpdated);
        }
        [SecuredOperation("admin,moderator")]
        public IResult Delete(CarImage carImage)
        
        {
            FileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(CarImageConstants.CarImagesDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
         
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(),CarImageConstants.AllCarImagesGetted);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id),CarImageConstants.CarImagesGettedById);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarIsHaveImage(carId));
            if (result!=null)
            {
                return new SuccessDataResult<List<CarImage>>(GetDefaultImage(), CarImageConstants.CarImagesGettedByCarId);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        #region BusinessRules

        private List<CarImage> GetDefaultImage()
        {
            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { ImagePath = "DefaultImage.png" });
            return carImage;
        }

        private IResult CheckCarIsHaveImage(int carId)
        {
            if (_carImageDal.GetAll(c => c.CarId == carId).Count == 0)
            {
                return new ErrorResult(CarImageConstants.CarImagesNotFound);
            }

            return new SuccessResult();
        }
        private IResult CheckCarImagesLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(CarImageConstants.CarImagesLimitExceded);
            }

            return new SuccessResult();
        }

        #endregion


    }
}
