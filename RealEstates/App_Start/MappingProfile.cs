using AutoMapper;
using RealEstates.Dtos;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstates.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<QuanHuyen, QuanHuyenDto>();

            // Dto to Domain
            Mapper.CreateMap<QuanHuyenDto, QuanHuyen>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}