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
    public class BranchManager:IBranchService
    {
        private IBranchDal _branchDal;

        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }

        public IDataResult<List<Branch>> GetAll()
        {
            return new SuccessDataResult<List<Branch>>(_branchDal.GetAll(),BranchConstants.AllBranchGetted);
        }

        public IDataResult<Branch> GetById(int id)
        {
            return new SuccessDataResult<Branch>(_branchDal.Get(b=>b.Id==id), BranchConstants.AllBranchGetted);
        }
        [ValidationAspect(typeof(BranchValidator))]
        //[SecuredOperation("admin,moderator")]s
        public IResult Add(Branch branch)
        {
            var result = BusinessRules.Run(CheckIfBranchExceeded(),CheckIfBranchNameExist(branch.Title));
            if (result!=null)
            {
                return result;
            }
            _branchDal.Add(branch);
            return new SuccessResult(BranchConstants.BranchAdded);
        }
        [SecuredOperation("admin,moderator")]
        public IResult Delete(Branch branch)
        {
            _branchDal.Delete(branch);
            return new SuccessResult(BranchConstants.BranchDeleted);
        }
        [ValidationAspect(typeof(BranchValidator))]
        [SecuredOperation("admin,moderator")]
        public IResult Update(Branch branch)
        {
            _branchDal.Update(branch);
            return new SuccessResult(BranchConstants.BranchUpdated);
        }

        public IDataResult<List<Branch>> GetByCityId(int cityId)
        {
            return new SuccessDataResult<List<Branch>>(_branchDal.GetAll(b => b.CityId == cityId));
        }

        #region BusinessRules

        private IResult CheckIfBranchExceeded()
        {
            var result = _branchDal.GetAll().Count;
            if (result>=5)
            {
                return new ErrorResult(BranchConstants.BranchLimitExceeded);
            }

            return new SuccessResult();
        }

        private IResult CheckIfBranchNameExist(string branchName)
        {
            var result = _branchDal.GetAll(b => b.Title == branchName).Any();
            if (result)
            {
                return new ErrorResult(BranchConstants.BranchNameAlreadyExist);
            }

            return new SuccessResult();
        }

        #endregion
    }
}
