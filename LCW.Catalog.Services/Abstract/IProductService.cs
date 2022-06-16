using LCW.Catalog.Core.Dtos.ProductDtos;
using LCW.Catalog.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Services.Abstract
{
    public interface IProductService
    {
        Task<Response<List<ProductDto>>> GetAll();
        Task<Response<List<ProductDto>>> GetAllByCategory(string categoryId);
        Task<Response<ProductDto>> Get(string productId, string userId);
        Task<NoDataResponse> Add(ProductAddDto productAddDto);
    }
}
