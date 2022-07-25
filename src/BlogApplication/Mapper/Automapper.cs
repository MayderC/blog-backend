
using AutoMapper;
using BlogApplication.DTOs.Auth;
using BlogCore.Entities;

namespace BlogApplication.Mapper
{
    public class Automapper : Profile
    {

        public Automapper()
        {
            CreateMap<LoginRequest, User>();
           
        }
    }

}
