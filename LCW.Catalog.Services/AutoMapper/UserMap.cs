using AutoMapper;
using LCW.Catalog.Core.Dtos.UserDtos;
using LCW.Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCW.Catalog.Services.AutoMapper
{
    public class UserMap : Profile
    {
        public UserMap()
        {
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
