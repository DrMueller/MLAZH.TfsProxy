using System;
using System.Collections.Generic;
using System.Text;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.DataAccess.WebModels.Services
{
    public interface IPatchDocumentBuilderFactory
    {
        IPatchDocumentBuilder CreateBuilder();
    }
}
