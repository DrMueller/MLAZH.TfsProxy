using AutoMapper;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Dtos.Profiles
{
    public class WorkItemDtoProfile : Profile
    {
        public WorkItemDtoProfile()
        {
            CreateMap<WorkItem, WorkItemDto>()
                .ForMember(d => d.Fields, c => c.MapFrom(f => f.Fields))
                .ForMember(d => d.Id, c => c.MapFrom(f => f.Id))
                .ForMember(d => d.Relations, c => c.MapFrom(f => f.Relations))
                .ForMember(d => d.Revision, c => c.MapFrom(f => f.Revision))
                .ForMember(d => d.Url, c => c.MapFrom(f => f.Url));
        }
    }
}