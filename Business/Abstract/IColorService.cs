using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IColorService
   {
       IResult Add(Color color);
       IResult Delete(Color color);
       IResult Update(Color color);
       IDataResult<List<Color>> GetAll();
       IDataResult<Color> GetById(int id);
   }
}
