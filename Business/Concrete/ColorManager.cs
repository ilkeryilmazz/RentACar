using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        [SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            var result = BusinessRules.Run(CheckIfColorhNameExist(color.Name));
            if (result!=null)
            {
                return result;
            }
            _colorDal.Add(color);
            return new SuccessResult(ColorConstants.ColorAdded);
        }
        [SecuredOperation("admin,moderator")]

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(ColorConstants.ColorDeleted);
        }
        [SecuredOperation("admin,moderator")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(ColorConstants.ColorUpdated);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), ColorConstants.AllColorGetted);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id), ColorConstants.ColorGettedById);
        }

        #region BusinessRules

        private IResult CheckIfColorhNameExist(string colorName)
        {
            var result = _colorDal.GetAll(c=>c.Name == colorName).Any();
            if (result)
            {
                return new ErrorResult(ColorConstants.ColorNameAlreadyExist);
            }

            return new SuccessResult();
        }

        #endregion
    }
}
