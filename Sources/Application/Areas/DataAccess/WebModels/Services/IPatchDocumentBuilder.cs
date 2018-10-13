using System.Collections.Generic;
using Mmu.Mlazh.TfsProxy.Application.Areas.DataAccess.WebModels.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.DataAccess.WebModels.Services
{
    public interface IPatchDocumentBuilder
    {
        IPatchDocumentBuilder AppendAddFieldOperation(string fieldPath, object fieldValue);

        IPatchDocumentBuilder AppendRelationOperation(string relation, string workItemUrl);

        IReadOnlyCollection<PatchDocument> Build();
    }
}
