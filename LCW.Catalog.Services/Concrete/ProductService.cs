using AutoMapper;
using LCW.Catalog.Core.Dtos.ProductDtos;
using LCW.Catalog.Core.Entities;
using LCW.Catalog.Data.Abstract;
using LCW.Catalog.Services.Abstract;
using LCW.Catalog.Services.Utilities;
using LCW.Catalog.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<NoDataResponse> Add(ProductAddDto productAddDto)
        {
            if (productAddDto != null)
            {
                var product = _mapper.Map<Product>(productAddDto);

                product.Id = Guid.NewGuid().ToString();

                var result=await _unitOfWork.Products.AddAsync(product);

                await _unitOfWork.CommitAsync();

                return new NoDataResponse(ResultStatus.Success, ResponseMessages.Product.Add(product.Name));
            }

            return new NoDataResponse(ResultStatus.Error, ResponseMessages.GeneralErrors.AddError());
        }

        public async Task<Response<ProductDto>> Get(string productId,string userId)
        {
            var product = await _unitOfWork.Products.GetAsync(a => a.Id == productId);

            var offer = await _unitOfWork.Offers.GetAllAsync(x => x.ProductId == productId && x.UserId == userId);

            if (product != null)
            {
                var productDto = _mapper.Map<ProductDto>(product);

                if (offer.Count>0)
                {
                    productDto.IsAlreadyOffered = true;
                }

                return new Response<ProductDto>(ResultStatus.Success, productDto);
            }
            return new Response<ProductDto>(ResultStatus.Error, ResponseMessages.Product.NotFound(false));
        }

        public async Task<Response<List<ProductDto>>> GetAll()
        {
            var products = await _unitOfWork.Products.GetAllAsync(null,x=>x.Category);

            if (products.Count >= 0)
            {
                var productDtos = _mapper.Map<List<Product>, List<ProductDto>>((List<Product>)products);

                return new Response<List<ProductDto>>(ResultStatus.Success, productDtos);
            }
            return new Response<List<ProductDto>>(ResultStatus.Error, ResponseMessages.Product.NotFound(true));
        }

        public async Task<Response<List<ProductDto>>> GetAllByCategory(string categoryId)
        {
            var products = await _unitOfWork.Products.GetAllAsync(a => a.CategoryId == categoryId,a=>a.Category);

            if (products.Count >= 0)
            {
                var productsDto = _mapper.Map<List<Product>, List<ProductDto>>((List<Product>)products);

                return new Response<List<ProductDto>>(ResultStatus.Success, productsDto);
            }
            return new Response<List<ProductDto>>(ResultStatus.Error, ResponseMessages.Product.NotFound(true));
        }
    }
}
