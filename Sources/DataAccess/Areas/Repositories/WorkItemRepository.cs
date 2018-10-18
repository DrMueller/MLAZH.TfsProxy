using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Repositories;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Models.PatchDocuments;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Models.WorkItems;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Services.PatchDocuments;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Services.WorkItems;
using Mmu.Mlh.ApplicationExtensions.Areas.Adapters.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Areas.Repositories
{
    public class WorkItemRepository : IWorkItemRepository
    {
        private readonly IAdapterResolver _adapterResolver;
        private readonly IPatchDocumentBuilderFactory _patchDocumentBuilderFactory;
        private readonly ITfsWorkItemRestProxy _restProxy;

        public WorkItemRepository(
            ITfsWorkItemRestProxy restProxy,
            IPatchDocumentBuilderFactory patchDocumentBuilderFactory,
            IAdapterResolver adapterResolver
        )
        {
            _restProxy = restProxy;
            _patchDocumentBuilderFactory = patchDocumentBuilderFactory;
            _adapterResolver = adapterResolver;
        }

        public async Task<WorkItem> LoadByIdAsync(int id)
        {
            var nativeWorkItem = await _restProxy.LoadByIdAsync(id);
            return Adapt(nativeWorkItem);
        }

        public async Task<WorkItem> PatchAsync(PatchWorkItem patchWorkItem)
        {
            var patchDocuments = CreatePatchDocuments(patchWorkItem.Relations, patchWorkItem.Fields);
            var nativeWorkItem = await _restProxy.PatchAsync(patchWorkItem.Id, patchDocuments);
            return Adapt(nativeWorkItem);
        }

        public async Task<WorkItem> PostAsync(PostWorkItem postWorkItem)
        {
            var patchDocuments = CreatePatchDocuments(postWorkItem.Relations, postWorkItem.Fields);
            var nativeWorkItem = await _restProxy.PostASync(postWorkItem.WorkItemTypeName, patchDocuments);
            return Adapt(nativeWorkItem);
        }

        private WorkItem Adapt(NativeWorkItem nativeWorkItem)
        {
            return _adapterResolver
                .ResolveByAdapteeTypes<NativeWorkItem, WorkItem>()
                .Adapt(nativeWorkItem);
        }

        private IReadOnlyCollection<PatchDocument> CreatePatchDocuments(IEnumerable<WorkItemRelation> relations, IEnumerable<WorkItemField> fields)
        {
            var patchDocumentBuilder = _patchDocumentBuilderFactory.CreateBuilder();

            fields.ForEach(f => patchDocumentBuilder.AppendAddFieldOperation(f.Name, f.Value));
            relations.ForEach(f => patchDocumentBuilder.AppendRelationOperation(f.RelationTypeDescription, f.TargetWorkItemId));

            return patchDocumentBuilder.Build();
        }
    }
}