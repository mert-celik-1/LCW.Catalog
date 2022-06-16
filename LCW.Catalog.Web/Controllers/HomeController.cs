using LCW.Catalog.Web.Models;
using LCW.Catalog.Web.Response;
using LCW.Catalog.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LCW.Catalog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly GetRequestBase _getRequestBase;
        private readonly PostRequestBase _postRequestBase;

        public HomeController(GetRequestBase getRequestBase, PostRequestBase postRequestBase)
        {
            _getRequestBase = getRequestBase;
            _postRequestBase = postRequestBase;
        }

        public async Task<IActionResult> Index(string categoryId="")
        {
            var categories = await _getRequestBase.SendGetRequest<List<CategoryDto>>("categories");

            var homeIndexViewModel = new HomeIndexViewModel
            {
                Categories = categories.Data
            };

            if (String.IsNullOrEmpty(categoryId))
            {
                var products = await _getRequestBase.SendGetRequest<List<ProductDto>>("products/getall");

                homeIndexViewModel.Products = products.Data;
            }
            else
            {
                var products = await _getRequestBase.SendGetRequest<List<ProductDto>>("products/getallbycategory?categoryId="+categoryId);

                homeIndexViewModel.Products = products.Data;
            }


            return View(homeIndexViewModel);
        }

        public async Task<IActionResult> Privacy()
        {
            var product = new ProductDto { Name = "asasas" };
            var asas = await _postRequestBase.SendPostRequest<NoDataResponse>("products/create", product);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
