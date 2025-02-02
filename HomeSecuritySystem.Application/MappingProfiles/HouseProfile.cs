using AutoMapper;
using HomeSecuritySystem.Application.Features.House.Commands.CreateHouse;
using HomeSecuritySystem.Application.Features.House.Commands.UpdateHouse;
using HomeSecuritySystem.Application.Features.House.Query.GetAllHouses;
using HomeSecuritySystem.Application.Features.House.Query.GetHouseDetails;
using HomeSecuritySystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeSecuritySystem.Application.MappingProfiles
{
    public class HouseProfile : Profile
    {
        public HouseProfile()
        {
            CreateMap<HouseDto , House>().ReverseMap();
            CreateMap<House, HouseDetailDto>();
            CreateMap<CreateHouseCommand, House>();
            CreateMap<UpdateHouseCommand, House>();
            CreateMap<UpdateHouseCommand, House>()
          .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        }
    }
}
