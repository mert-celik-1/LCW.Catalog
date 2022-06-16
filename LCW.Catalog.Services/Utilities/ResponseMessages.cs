using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Services.Utilities
{
    public static class ResponseMessages
    {
        public static class Product
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Ürünler bulunamadı.";
                return "Böyle bir ürün bulunamadı.";
            }
            public static string Add(string productTitle)
            {
                return $"{productTitle} isimli ürün başarıyla eklenmiştir.";
            }

        }

       

       
        public static class User
        {
            public static string Create()
            {
                return "Kullanıcı başarıyla kaydedildi.";
            }

            public static string NotFound()
            {
                return "Kullanıcı bulunamadı.";
            }

            public static string Get(string userName)
            {
                return $"{userName} isimli kullanıcı başarıyla getirildi.";
            }

        }

        public static class GeneralErrors
        {
            public static string AddError()
            {
                return "Veri kaydedilirken bir hata meydana geldi";
            }
        }
    }
}
