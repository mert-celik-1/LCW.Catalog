using FluentValidation;
using LCW.Catalog.Core.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCW.Catalog.API.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş bırakılamaz");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş bırakılamaz");

            RuleFor(x => x.Password).Length(8, 20).WithMessage("Şifre alanı 8 ile 20 karakter uzunluğunda olmalıdır");
        }
    }
}
