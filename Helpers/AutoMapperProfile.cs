using AutoMapper;
using AssetB.DTO.Users;
using AssetB.DTO;
using AssetB.Models;

namespace AssetB.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(){
            CreateMap<User, UserDTO>();
            CreateMap<RegisterDTO, User>();
            CreateMap<UpdateUserDTO, User>();

            CreateMap<AssetMaintain, AssetMaintainDTO>();
            CreateMap<AssetMaintainDTO, AssetMaintain>();
        }
        
    }
}