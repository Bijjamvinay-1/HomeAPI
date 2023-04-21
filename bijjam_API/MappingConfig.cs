using AutoMapper;
using bijjam_API.Model;
using bijjam_API.Model.DTO;
using Microsoft.AspNetCore.Http.HttpResults;

namespace bijjam_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Home, HomeDTO>();
            CreateMap<HomeDTO, Home>();     
            //Byusing two Lines ..We can also use ""ReverseMap();""
            CreateMap<Home, HomeCreateDTO>().ReverseMap();
            CreateMap<Home, HomeUpdateDTO>().ReverseMap();

        }  
    }
}
