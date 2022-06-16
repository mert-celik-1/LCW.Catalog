using LCW.Catalog.Web.Enums;
using LCW.Catalog.Web.Models;
using LCW.Catalog.Web.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCW.Catalog.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly GetRequestBase _getRequestBase;
        private readonly PostRequestBase _postRequestBase;

        public ProductsController(GetRequestBase getRequestBase, PostRequestBase postRequestBase)
        {
            _getRequestBase = getRequestBase;
            _postRequestBase = postRequestBase;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _getRequestBase.SendGetRequest<List<CategoryDto>>("categories");

            ViewBag.categoryList = new SelectList(categories.Data, "Id", "Name");
            ViewBag.colors = new SelectList(Enum.GetValues(typeof(Color)));
            ViewBag.brands = new SelectList(Enum.GetValues(typeof(Brand)));
            ViewBag.status = new SelectList(Enum.GetValues(typeof(Status)));


            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDto productAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _postRequestBase.SendPostRequest<NoDataResponse>("products/Create", productAddDto);

                if (result.ResultStatus == ResultStatus.Success)
                {
                    return Redirect("/Home/Index");
                }
            }

            var categories = await _getRequestBase.SendGetRequest<List<CategoryDto>>("categories");


            ViewBag.categoryList = new SelectList(categories.Data, "Id", "Name");
            ViewBag.colors = new SelectList(Enum.GetValues(typeof(Color)));
            ViewBag.brands = new SelectList(Enum.GetValues(typeof(Brand)));
            ViewBag.status = new SelectList(Enum.GetValues(typeof(Status)));

            return View(productAddDto);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string productId)
        {
            var result = await _getRequestBase.SendGetRequest<ProductDto>("products/GetById?productId=" + productId);

            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> MakeOffer(decimal price, string productId)
        {
            var data = new OfferDto { ProductId = productId, OfferedPrice = price };

            var result = await _postRequestBase.SendPostRequest<OfferDto>("offers/MakeAnOffer", data);

            return Redirect("/Home/Index");
        }

        [HttpGet]
        public async Task<IActionResult> Withdraw(string productId)
        {
            var result = await _getRequestBase.SendGetRequest<ProductDto>("offers/WithdrawOffer?productId=" + productId);

            return Redirect("/Home/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Buy(decimal price, string Id)
        {
            var data = new OfferDto { OfferedPrice = price, ProductId = Id };
    
            var result = await _postRequestBase.SendPostRequest<OfferDto>("offers/Buy", data);

            return Redirect("/Home/Index");
        }
    }
}
