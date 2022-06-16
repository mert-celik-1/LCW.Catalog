using LCW.Catalog.Core.Dtos.AuthenticationDtos;
using LCW.Catalog.Core.Dtos.UserDtos;
using LCW.Catalog.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Services.Abstract
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto);

        Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken);

        Task<Response<NoDataResponse>> RevokeRefreshToken(string refreshToken);

    }
}
