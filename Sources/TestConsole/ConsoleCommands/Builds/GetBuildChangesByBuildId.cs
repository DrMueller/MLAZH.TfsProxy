using System;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Builds.App.DtoModeling.Services;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Newtonsoft.Json;

namespace Mmu.Mlazh.TfsProxy.TestConsole.ConsoleCommands.Builds
{
    public class GetBuildChangesByBuildId : IConsoleCommand
    {
        private readonly IBuildChangeDtoDataService _buildChangeDtoDataService;
        public string Description { get; } = "Get Build Changes by Build ID";
        public ConsoleKey Key { get; } = ConsoleKey.D3;

        public GetBuildChangesByBuildId(IBuildChangeDtoDataService buildChangeDtoDataService)
        {
            _buildChangeDtoDataService = buildChangeDtoDataService;
        }

        public async Task ExecuteAsync()
        {
            var itm = await _buildChangeDtoDataService.LoadByBuildIdAsync(1172);
            Console.WriteLine(JsonConvert.SerializeObject(itm));
        }
    }
}