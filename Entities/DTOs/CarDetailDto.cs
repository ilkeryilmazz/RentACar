using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entites;
using Entities.Concrete;

namespace Entities.DTOs
{
   public class CarDetailDto:IDto
    {
        public int Id{ get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string Description { get; set; }
        public decimal DailyPrice { get; set; }

        public List<CarImageDetailDto> Images { get ; set; } 
            

    }
}
