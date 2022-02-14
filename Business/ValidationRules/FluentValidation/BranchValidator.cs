using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
   public class BranchValidator:AbstractValidator<Branch>
    {
        public BranchValidator()
        {
            RuleFor(b => b.Address).MinimumLength(5);
            RuleFor(b => b.Title).MinimumLength(5);
        }
    }
}
