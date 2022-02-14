﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserVerifyValidator:AbstractValidator<UserVerify>
    {
        public UserVerifyValidator()
        {
            RuleFor(u => u.EmailVerifyStatus).NotEqual(true);
            RuleFor(u => u.EmailVerifyToken).NotEmpty();
        }
    }
}
