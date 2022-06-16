using AutoMapper;
using LCW.Catalog.Core.Dtos.ProductDtos;
using LCW.Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Services.AutoMapper
{
    public class ProductMap : Profile
    {
        public ProductMap()
        {
            CreateMap<ProductAddDto, Product>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
        }

    }
}
