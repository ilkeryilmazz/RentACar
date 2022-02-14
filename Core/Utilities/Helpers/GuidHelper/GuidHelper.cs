using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public static class GuidHelper
    {
        public static Guid CreateGuid()
        {
            return Guid.NewGuid();
        }
    }
}
