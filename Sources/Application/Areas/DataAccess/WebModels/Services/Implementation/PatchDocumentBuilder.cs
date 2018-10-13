﻿using System.Collections.Generic;
using Mmu.Mlazh.TfsProxy.Application.Areas.DataAccess.WebModels.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.DataAccess.WebModels.Services.Implementation
{
    public class PatchDocumentBuilder : IPatchDocumentBuilder
    {
        private readonly List<PatchDocument> _patchDocuments;

        public PatchDocumentBuilder()
        {
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

        public IPatchDocumentBuilder AppendRelationOperation(string relation, string workItemUrl)
        {
            const string FormattedPath = @"/relations/-";

            var workItemRelation = new PatchDocumentRelation
            {
                Rel = relation,
                Url = workItemUrl
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
    }
}