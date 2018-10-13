using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Areas.DataAccess.Adapters;
using Mmu.Mlazh.TfsProxy.Application.Areas.DataAccess.WebModels.Models;
using Mmu.Mlazh.TfsProxy.Application.Areas.DataAccess.WebModels.Services;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;
using Mmu.Mlazh.TfsProxy.Application.Infrastructure.TfsAccess.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.DataAccess.Repositories.Implementation
{
    public class WorkItemRepository : IWorkItemRepository
    {
        private readonly INativeWorkItemAdapter _nativeWorkitemAdapter;
        private readonly IPatchDocumentBuilderFactory _patchDocumentBuilderFactory;
        private readonly ITfsWorkItemRestProxy _restProxy;

        public WorkItemRepository(
            ITfsWorkItemRestProxy restProxy,
            IPatchDocumentBuilderFactory patchDocumentBuilderFactory,
            INativeWorkItemAdapter nativeWorkitemAdapter
        )
        {
            _restProxy = restProxy;
            _patchDocumentBuilderFactory = patchDocumentBuilderFactory;
            _nativeWorkitemAdapter = nativeWorkitemAdapter;
        }

        public async Task<WorkItem> LoadByIdAsync(int id)
        {
            var nativeWorkItem = await _restProxy.LoadByIdAsync(150);
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