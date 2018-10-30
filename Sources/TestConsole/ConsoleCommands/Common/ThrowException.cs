using System;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Newtonsoft.Json;

namespace Mmu.Mlazh.TfsProxy.TestConsole.ConsoleCommands.Common
{
    public class ThrowException : IConsoleCommand
    {
        public async Task ExecuteAsync()
        {
            var result = await AzureFunctions.Builds.Functions.GetBuildChangesByBuildId.GetAsync(null, null, -1);
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        public string Description { get; } = "Throw Exception";
        public ConsoleKey Key { get; } = ConsoleKey.F1;
    }
}
