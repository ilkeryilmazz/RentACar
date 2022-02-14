using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entites.Concrete;
using Entities.DTOs;
using FluentValidation;
using FluentValidation.Results;

namespace Business.ValidationRules.FluentValidation
{
    public class UserForRegisterDtoValidator:AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterDtoValidator()
        {
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.Password).NotEmpty();
        }
    }
}
