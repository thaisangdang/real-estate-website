using AutoMapper;
using RealEstates.Dtos;
using RealEstates.Models;

namespace RealEstates.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<QuanHuyen, QuanHuyenDto>();
            Mapper.CreateMap<LoaiNhaDat, LoaiNhaDatDto>();
            Mapper.CreateMap<NhaDat, NhaDatDto>();

            // Dto to Domain
            Mapper.CreateMap<QuanHuyenDto, QuanHuyen>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            Mapper.CreateMap<LoaiNhaDatDto, LoaiNhaDat>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            Mapper.CreateMap<NhaDatDto, NhaDat>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}