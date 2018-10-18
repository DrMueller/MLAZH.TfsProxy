using System.Collections.Generic;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Models.PatchDocuments;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Services.PatchDocuments
{
    public interface IPatchDocumentBuilder
    {
        IPatchDocumentBuilder AppendAddFieldOperation(string fieldPath, object fieldValue);

        IPatchDocumentBuilder AppendRelationOperation(string relation, int targetWorkItemId);

        IReadOnlyCollection<PatchDocument> Build();
    }
}