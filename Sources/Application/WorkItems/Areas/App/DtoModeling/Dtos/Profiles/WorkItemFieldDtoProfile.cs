using AutoMapper;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Dtos.Profiles
{
    public class WorkItemFieldDtoProfile : Profile
    {
        public WorkItemFieldDtoProfile()
        {
            CreateMap<WorkItemField, WorkItemFieldDto>()
                .ForMember(d => d.Name, c => c.MapFrom(f => f.Name))
                .ForMember(d => d.Value, c => c.MapFrom(f => f.Value));
        }
    }
}