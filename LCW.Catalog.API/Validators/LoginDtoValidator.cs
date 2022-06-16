using FluentValidation;
using LCW.Catalog.Core.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCW.Catalog.API.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş bırakılamaz");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş bırakılamaz");

            RuleFor(x => x.Password).Length(8, 20).WithMessage("Şifre alanı 8 ile 20 karakter uzunluğunda olmalıdır");
        }
    }
}
