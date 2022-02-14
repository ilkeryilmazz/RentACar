using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserVerifyService
    {
        IDataResult<UserVerify> Add(string mail);
        IResult Delete(UserVerify userVerify);
        IResult Update(UserVerify userVerify);
        IDataResult<List<UserVerify>> GetAll();
        IDataResult<UserVerify> GetByUserId(int userId);
        UserVerify GetByVerifyToken(string verifyToken);
        IDataResult<UserVerify> GetById(int id);
        IResult Verify(string verifyToken);
    }
}
