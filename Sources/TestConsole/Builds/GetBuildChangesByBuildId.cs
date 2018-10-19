using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Builds.App.DtoModeling.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using Newtonsoft.Json;

namespace Mmu.Mlazh.TfsProxy.TestConsole.Builds
{
    public class GetBuildChangesByBuildId : IConsoleCommand
    {
        public string Description { get; } = "Get Build Changes by Build ID";
        public ConsoleKey Key { get; } = ConsoleKey.D3;

        public async Task ExecuteAsync()
        {
            try
            {
                var service = ProvisioningServiceSingleton.Instance.GetService<IBuildChangeDtoDataService>();
                var itm = await service.LoadByBuildIdAsync(1172);
                Console.WriteLine(JsonConvert.SerializeObject(itm));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Debugger.Break();
            }
        }
    }
}