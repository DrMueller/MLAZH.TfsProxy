using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Repositories;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.Repositories;
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
                    scanner.WithDefaultConventions();
                });

            For<IWorkItemRepository>().Use<WorkItemRepository>();
        }
    }
}