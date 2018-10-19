using Mmu.Mlazh.TfsProxy.DataAccess.Common.Infrastructure.DependencyInjection;

namespace Mmu.Mlazh.TfsProxy.Dependencies
{
    // https://stackoverflow.com/questions/2241961/how-to-get-all-types-in-a-referenced-assembly
    public static class DependenciesProvider
    {
        public static void ProvideDependencencies()
        {
#pragma warning disable CA1806 // Do not ignore method results

            // ReSharper disable once ObjectCreationAsStatement
            new DataAccessRegistry();
#pragma warning restore CA1806 // Do not ignore method results
        }
    }
}