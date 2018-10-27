using AutoMapper;
using Mmu.Mlazh.TfsProxy.Application.Builds.Domain.Models;
using Mmu.Mlazh.TfsProxy.DataAccess.Builds.Areas.DataModeling.Models;
using Mmu.Mlh.Adapters.Areas.Services;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Builds.Areas.Repositories.Adapters
{
    public class NativeBuildChangeAdapter : AdapterBase<NativeBuildChange, BuildChange>
    {
        public NativeBuildChangeAdapter(IMapper mapper) : base(mapper)
        {
        }

        public override BuildChange Adapt(NativeBuildChange dto)
        {
            return new BuildChange(
                dto.Id,
                dto.Location,
                dto.Message,
                dto.Timestamp);
        }
    }
}