using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
   public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.CarId).NotEqual(0);
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.CustomerId).NotEqual(0);
            RuleFor(r => r.RentAddress).NotEmpty();
            RuleFor(r => r.ReturnAddress).NotEmpty();
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.ReturnDate).NotEmpty();
            RuleFor(r => r.ReturnDate).Must(NotNow);
        }

        private bool NotNow(DateTime arg)
        {
            if (arg==DateTime.Now)
            {
                return false;
            }

            return true;
        }
    }
}
