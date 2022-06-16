using LCW.Catalog.Web.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LCW.Catalog.Web.Models
{
    public class ProductAddDto
    {
        [Required(ErrorMessage ="İsim alanı zorunludur")]
        [MaxLength(100,ErrorMessage ="İsim alanı maksimum 100 karakter uzunluğunda olabilir")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Açıklama alanı zorunludur")]
        [MaxLength(500,ErrorMessage = "Açıklama alanı maksimum 500 karakter uzunluğunda olabilir")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Kategori alanı zorunludur")]
        public string CategoryId { get; set; }
       
        [Required(ErrorMessage = "Renk alanı zorunludur")]

        [EnumDataType(typeof(Color), ErrorMessage = "Renk alanı zorunludur")]
        public Color Color { get; set; }
       
        [EnumDataType(typeof(Status),ErrorMessage ="Kullanım durumu alanı zorunludur")]
        public Status Status { get; set; }


        public Brand Brand { get; set; }

        [RegularExpression(@"^\d+(\.\d{1,2})?$",ErrorMessage ="Virgülden sonra 2 basamak koyabilirsiniz")]
        [Range(0, 9999999999999999.99,ErrorMessage ="Maksimum 18 haneli olabilir")]
        public decimal Price { get; set; }
        public bool IsOfferable { get; set; }
    }
}
