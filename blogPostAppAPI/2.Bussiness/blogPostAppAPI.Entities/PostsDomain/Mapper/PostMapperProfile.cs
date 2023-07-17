using AutoMapper;
using blogPostAppAPI.DataAccess.Domains;
using blogPostAppAPI.Entities.PostsDomain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace blogPostAppAPI.Entities.PostsDomain.Mapper
{
    public class PostMapperProfile : Profile
    {
        public PostMapperProfile() : base("PostMapperProfile")
        {
            CreateMap<PostDTO, Post>().ReverseMap();
        }
    }
}
