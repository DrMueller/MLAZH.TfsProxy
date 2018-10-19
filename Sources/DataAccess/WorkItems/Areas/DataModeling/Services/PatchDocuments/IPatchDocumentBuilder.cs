using System.Collections.Generic;
using Mmu.Mlazh.TfsProxy.DataAccess.WorkItems.Areas.DataModeling.Models.PatchDocuments;

namespace Mmu.Mlazh.TfsProxy.DataAccess.WorkItems.Areas.DataModeling.Services.PatchDocuments
{
    public interface IPatchDocumentBuilder
    {
        IPatchDocumentBuilder AppendAddFieldOperation(string fieldPath, object fieldValue);

        IPatchDocumentBuilder AppendRelationOperation(string relation, int targetWorkItemId);

        IReadOnlyCollection<PatchDocument> Build();
    }
}