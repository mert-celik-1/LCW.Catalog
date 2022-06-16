using LCW.Catalog.Core.Dtos.UserDtos;
using LCW.Catalog.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Services.Abstract
{
    public interface IUserService
    {
        Task<Response<UserDto>> CreateUserAsync(CreateUserDto createUserDto);

        Task<Response<UserDto>> GetUserByNameAsync(string userName);
    }
}
