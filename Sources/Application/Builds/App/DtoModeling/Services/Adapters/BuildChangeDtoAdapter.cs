using AutoMapper;
using Mmu.Mlazh.TfsProxy.Application.Builds.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.Builds.Domain.Models;
using Mmu.Mlh.Adapters.Areas.Services;

namespace Mmu.Mlazh.TfsProxy.Application.Builds.App.DtoModeling.Services.Adapters
{
    public class BuildChangeDtoAdapter : AdapterBase<BuildChangeDto, BuildChange>
    {
        public BuildChangeDtoAdapter(IMapper mapper) : base(mapper)
        {
        }

        public override BuildChange Adapt(BuildChangeDto dto)
        {
            return new BuildChange(
                dto.Id,
                dto.Location,
                dto.Message,
                dto.Timestamp);
        }
    }
}