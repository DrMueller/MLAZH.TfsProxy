using AutoMapper;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Dtos.Profiles
{
    public class PatchWorkItemDtoProfile : Profile
    {
        public PatchWorkItemDtoProfile()
        {
            CreateMap<PatchWorkItem, PatchWorkItemDto>()
                .ForMember(f => f.Fields, c => c.MapFrom(f => f.Fields))
                .ForMember(f => f.Id, c => c.MapFrom(f => f.Id))
                .ForMember(f => f.Relations, c => c.MapFrom(f => f.Relations));
        }
    }
}