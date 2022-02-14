using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Branch:IEntity
    {
        
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
    }
}
