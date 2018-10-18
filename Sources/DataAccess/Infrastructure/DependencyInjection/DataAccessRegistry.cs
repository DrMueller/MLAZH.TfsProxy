using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Repositories;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Services.PatchDocuments;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.Repositories;
using Mmu.Mlh.ApplicationExtensions.Areas.Adapters.Services;
using StructureMap;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Infrastructure.DependencyInjection
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