using AutoMapper;
using blogPostAppAPI.DataAccess.Domains;
using blogPostAppAPI.Entities.UsersDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace blogPostAppAPI.Entities.UsersDomain.Mapper
{
    public class UserMapperProfile : Profile 
    {
        public UserMapperProfile() : base("UserMapperProfile")
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<UserUpdateDTO, User>().ReverseMap();
        }
    }
}
