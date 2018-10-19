using System.Collections.Generic;
using Mmu.Mlazh.TfsProxy.Application.Common.Infrastructure.Settings.TfsSettings.Models;
using Mmu.Mlazh.TfsProxy.Application.Common.Infrastructure.Settings.TfsSettings.Services;
using Mmu.Mlazh.TfsProxy.DataAccess.WorkItems.Areas.DataModeling.Models.PatchDocuments;

namespace Mmu.Mlazh.TfsProxy.DataAccess.WorkItems.Areas.DataModeling.Services.PatchDocuments.Implementation
{
    public class PatchDocumentBuilder : IPatchDocumentBuilder
    {
        private readonly List<PatchDocument> _patchDocuments;
        private readonly TfsSettings _tfsSettings;

        public PatchDocumentBuilder(ITfsSettingsProvider tfsSettingsProvider)
        {
            _tfsSettings = tfsSettingsProvider.ProvideTfsSettings();
            _patchDocuments = new List<PatchDocument>();
        }

        public IPatchDocumentBuilder AppendAddFieldOperation(string fieldPath, object fieldValue)
        {
            var formattedPath = @"/fields/" + fieldPath;

            var patchDocument = new PatchDocument
            {
                Op = PatchDocumentOperationType.Add,
                Path = formattedPath,
                Value = fieldValue.ToString()
            };

            _patchDocuments.Add(patchDocument);
            return this;
        }

        public IPatchDocumentBuilder AppendRelationOperation(string relation, int targetWorkItemId)
        {
            const string FormattedPath = @"/relations/-";

            var workItemRelation = new PatchDocumentRelation
            {
                Rel = relation,
                Url = CreateWorkItemPath(targetWorkItemId)
            };

            var patchDocument = new PatchDocument
            {
                Op = PatchDocumentOperationType.Add,
                Path = FormattedPath,
                Value = workItemRelation
            };

            _patchDocuments.Add(patchDocument);
            return this;
        }

        public IReadOnlyCollection<PatchDocument> Build()
        {
            return _patchDocuments;
        }

        private string CreateWorkItemPath(int targetWorkItemId)
        {
            return string.Concat(_tfsSettings.TfsBaseProjectPath, $"_apis/wit/workItems/{targetWorkItemId}");
        }
    }
}