using AutoMapper;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.Dtos.Profiles
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