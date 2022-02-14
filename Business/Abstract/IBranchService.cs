using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBranchService
    {
        IDataResult<List<Branch>> GetAll();
        IDataResult<Branch> GetById(int id);
        IResult Add(Branch branch);
        IResult Delete(Branch branch);
        IResult Update(Branch branch);
        IDataResult<List<Branch>> GetByCityId(int cityId);
    }
}
