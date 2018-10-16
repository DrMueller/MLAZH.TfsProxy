using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Repositories;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Models.PatchDocuments;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Services.PatchDocuments;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Services.WorkItems;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.Repositories.Adapters;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Areas.Repositories
{
    public class WorkItemRepository : IWorkItemRepository
    {
        private readonly IWorkItemAdapter _nativeWorkitemAdapter;
        private readonly IPatchDocumentBuilderFactory _patchDocumentBuilderFactory;
        private readonly ITfsWorkItemRestProxy _restProxy;

        public WorkItemRepository(
            ITfsWorkItemRestProxy restProxy,
            IPatchDocumentBuilderFactory patchDocumentBuilderFactory,
            IWorkItemAdapter nativeWorkitemAdapter
        )
        {
            _restProxy = restProxy;
            _patchDocumentBuilderFactory = patchDocumentBuilderFactory;
            _nativeWorkitemAdapter = nativeWorkitemAdapter;
        }

        public async Task<WorkItem> LoadByIdAsync(int id)
        {
            var nativeWorkItem = await _restProxy.LoadByIdAsync(id);
            return _nativeWorkitemAdapter.Adapt(nativeWorkItem);
        }

        public async Task<WorkItem> PatchAsync(PatchWorkItem patchWorkItem)
        {
            var patchDocuments = CreatePatchDocuments(patchWorkItem);
            var nativeWorkItem = await _restProxy.PatchAsync(patchWorkItem.Id, patchDocuments);

            return _nativeWorkitemAdapter.Adapt(nativeWorkItem);
        }

        private IReadOnlyCollection<PatchDocument> CreatePatchDocuments(PatchWorkItem patchWorkItem)
        {
            var patchDocumentBuilder = _patchDocumentBuilderFactory.CreateBuilder();

            patchWorkItem.Fields.ForEach(f => patchDocumentBuilder.AppendAddFieldOperation(f.Name, f.Value));
            patchWorkItem.Relations.ForEach(f => patchDocumentBuilder.AppendRelationOperation(f.RelationTypeDescription, f.TargetWorkItemUrl.AbsolutePath));

            return patchDocumentBuilder.Build();
        }
    }
}