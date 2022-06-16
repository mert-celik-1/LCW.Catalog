using LCW.Catalog.Core.Dtos.ProductDtos;
using LCW.Catalog.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCW.Catalog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public ProductsController(IProductService productService, IUserService userService)
        {
            _productService = productService;
            _userService = userService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAll();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByCategory(string categoryId)
        {
            var result = await _productService.GetAllByCategory(categoryId);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery]string productId)
        {
            var name = User.Identity.Name;

            var user = await _userService.GetUserByNameAsync(name);

            var result = await _productService.Get(productId,user.Data.Id);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(ProductAddDto productAddDto)
        {
            var result = await _productService.Add(productAddDto);

            return Ok(result);
        }


    }
}
