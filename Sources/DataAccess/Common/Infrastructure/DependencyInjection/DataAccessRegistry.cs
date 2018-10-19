using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.Domain.Repositories;
using Mmu.Mlazh.TfsProxy.DataAccess.WorkItems.Areas.DataModeling.Services.PatchDocuments;
using Mmu.Mlazh.TfsProxy.DataAccess.WorkItems.Areas.Repositories;
using Mmu.Mlh.ApplicationExtensions.Areas.Adapters.Services;
using StructureMap;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Common.Infrastructure.DependencyInjection
{
    public class DataAccessRegistry : Registry
    {
        public DataAccessRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<DataAccessRegistry>();
                    scanner.AddAllTypesOf(typeof(IAdapter<,>));
                    scanner.WithDefaultConventions();
                });

            For(typeof(IAdapter<,>)).Singleton();
            For<IWorkItemRepository>().Use<WorkItemRepository>();
            For<IPatchDocumentBuilder>().AlwaysUnique();
        }
    }
}