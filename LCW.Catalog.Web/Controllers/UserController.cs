using LCW.Catalog.Web.Models;
using LCW.Catalog.Web.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Memory;

namespace LCW.Catalog.Web.Controllers
{
    public class UserController : Controller
    {

        private readonly GetRequestBase _getRequestBase;
        private readonly PostRequestBase _postRequestBase;
        private readonly IMemoryCache _memoryCache;

        public UserController(GetRequestBase getRequestBase, PostRequestBase postRequestBase, IMemoryCache memoryCache)
        {
            _getRequestBase = getRequestBase;
            _postRequestBase = postRequestBase;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(CreateUserDto createUserDto)
        {

            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/Home/Index");
            }

            if (ModelState.IsValid)
            {
                await _postRequestBase.SendPostRequest<Response<UserDto>>("user/createuser", createUserDto);

                UserDto userDto = new UserDto { Email = createUserDto.Email, Password = createUserDto.Password, UserName = createUserDto.UserName };

                return await Login(userDto);

            }

            return View(createUserDto);
          
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserDto userDto)
        {

            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/Home/Index");
            }

            if (ModelState.IsValid)
            {
                var result = await _postRequestBase.SendPostRequest<TokenDto>("auth/createtoken", userDto);

                if (result.Data is not null)
                {

                    MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(30),
                        Priority= CacheItemPriority.NeverRemove
                    };

                    _memoryCache.Set("Token", result.Data.AccessToken,memoryCacheEntryOptions);

                    List<Claim> claims = new List<Claim> {
                        new Claim(ClaimTypes.Name,userDto.Email),


                    };
                    var identity = new ClaimsIdentity(claims,
                          CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                    return Redirect("/Home/Index");
                }

                ModelState.AddModelError("", "Bu bilgilerde bir kullanıcı bulunamadı");

                
            }

            return View(userDto);
        }



        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            _memoryCache.Remove("Token");

            return Redirect("/Home/Index");
        }



    }
}
