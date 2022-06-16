using LCW.Catalog.Core.Dtos.AuthenticationDtos;
using LCW.Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Services.Abstract
{
    public interface ITokenService
    {
        TokenDto CreateToken(User user);
    }
}
