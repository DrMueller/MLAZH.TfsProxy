using AutoMapper;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Dtos.Profiles
{
    public class WorkItemRelationDtoProfile : Profile
    {
        public WorkItemRelationDtoProfile()
        {
            CreateMap<WorkItemRelation, WorkItemRelationDto>()
                .ForMember(d => d.RelationTypeDescription, c => c.MapFrom(f => f.RelationTypeDescription))
                .ForMember(d => d.TargetWorkItemId, c => c.MapFrom(f => f.TargetWorkItemId));
        }
    }
}