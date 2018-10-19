using AutoMapper;
using Mmu.Mlazh.TfsProxy.Application.Builds.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Builds.App.DtoModeling.Dtos.Profiles
{
    public class BuildChangeDtoProfile : Profile
    {
        public BuildChangeDtoProfile()
        {
            CreateMap<BuildChange, BuildChangeDto>()
                .ForMember(d => d.Id, c => c.MapFrom(f => f.Id))
                .ForMember(d => d.Location, c => c.MapFrom(f => f.Location))
                .ForMember(d => d.Message, c => c.MapFrom(f => f.Message))
                .ForMember(d => d.Timestamp, c => c.MapFrom(f => f.Timestamp));
        }
    }
}