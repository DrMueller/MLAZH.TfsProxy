////using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Repositories;
////using Mmu.Mlazh.TfsProxy.DataAccess.Areas.Repositories;
////using StructureMap;

////namespace Mmu.Mlazh.TfsProxy.AzureFunctions.Infrastructure.DependencyInjection
////{
////    public class AzureFunctionsRegistry : Registry
////    {
////        public AzureFunctionsRegistry()
////        {
////            Scan(
////                scanner =>
////                {
////                    scanner.AssemblyContainingType<AzureFunctionsRegistry>();
////                    scanner.WithDefaultConventions();
////                });

////            For<IWorkItemRepository>().Use<WorkItemRepository>();
////        }
////    }
////}