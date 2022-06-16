using AutoMapper;
using LCW.Catalog.Core.Dtos.CategoryDtos;
using LCW.Catalog.Core.Entities;
using LCW.Catalog.Data.Abstract;
using LCW.Catalog.Services.Abstract;
using LCW.Catalog.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CategoryService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    

        public async Task<Response<List<CategoryDto>>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();

            var categoriesDto = _mapper.Map<List<Category>, List<CategoryDto>>((List<Category>)categories);

            return new Response<List<CategoryDto>>(ResultStatus.Success, categoriesDto);
        }

     
    }
}
