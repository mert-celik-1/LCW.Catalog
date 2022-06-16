using AutoMapper;
using LCW.Catalog.Core.Dtos.CategoryDtos;
using LCW.Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Services.AutoMapper
{
    public class CategoryMap : Profile
    {
        public CategoryMap()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
        }

    }
}
