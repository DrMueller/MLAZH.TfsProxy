using AutoMapper;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Dtos.Profiles
{
    public class PostWorkItemDtoProfile : Profile
    {
        public PostWorkItemDtoProfile()
        {
            CreateMap<PostWorkItem, PostWorkItemDto>()
                .ForMember(d => d.Fields, c => c.MapFrom(f => f.Fields))
                .ForMember(d => d.Relations, c => c.MapFrom(f => f.Relations))
                .ForMember(d => d.WorkItemTypeName, c => c.MapFrom(f => f.WorkItemTypeName));
        }
    }
}