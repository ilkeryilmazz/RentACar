using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
   public class Rental:IEntity
    {
        public int Id{ get; set; }
        public int CarId{ get; set; }
        public int CustomerId{ get; set; }
        public string RentAddress{ get; set; }
        public string ReturnAddress{ get; set; }
        public DateTime RentDate{ get; set; }
        public DateTime ReturnDate{ get; set; }
    }
}
