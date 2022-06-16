using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LCW.Catalog.Web.Models
{
    public class CreateUserDto
    {
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required(ErrorMessage ="Email alanı zorunludur")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur")]
        [DataType(DataType.Password)]
        [MinLength(8,ErrorMessage ="Şifre alanı en az 8 karakter olmalıdır")]
        [MaxLength(20,ErrorMessage ="Şifre alanı en fazla 20 karakter olmalıdır")]
        public string Password { get; set; }
    }
}
