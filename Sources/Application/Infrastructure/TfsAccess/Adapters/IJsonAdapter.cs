using System.Collections.Generic;
using Mmu.Mlazh.TfsProxy.Application.Infrastructure.TfsAccess.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Infrastructure.TfsAccess.Adapters
{
    public interface IJsonAdapter
    {
        List<NativeWorkItem> AdaptList(string jsonString);

        NativeWorkItem AdaptWorkItem(string jsonString);
    }
}