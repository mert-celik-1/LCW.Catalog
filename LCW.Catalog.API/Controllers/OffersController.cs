using LCW.Catalog.Core.Dtos.OfferDtos;
using LCW.Catalog.Services.Abstract;
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
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _offerService;
        private readonly IUserService _userService;

        public OffersController(IOfferService offerService,IUserService userService)
        {
            _offerService = offerService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> MakeAnOffer(OfferDto offerDto)
        {
            var name=User.Identity.Name;

            var user = await _userService.GetUserByNameAsync(name);

            offerDto.UserId = user.Data.Id;

            var result = await _offerService.MakeAnOffer(offerDto);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> WithdrawOffer(string productId)
        {
            var name = User.Identity.Name;

            var user = await _userService.GetUserByNameAsync(name);

            var result = await _offerService.WithdrawOffer(productId,user.Data.Id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Buy(OfferDto offerDto)
        {
            var name = User.Identity.Name;

            var user = await _userService.GetUserByNameAsync(name);

            offerDto.UserId = user.Data.Id;

            var result = await _offerService.Buy(offerDto);

            return Ok(result);
        }

    }
}
