using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.AzureFunctions.Builds.Functions;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Newtonsoft.Json;

namespace Mmu.Mlazh.TfsProxy.TestConsole.Common
{
    public class ThrowException : IConsoleCommand
    {
        public async Task ExecuteAsync()
        {
            var result = await GetBuildChangesByBuildId.GetAsync(null, null, -1);
            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        public string Description { get; } = "Throw Exception";
        public ConsoleKey Key { get; } = ConsoleKey.F1;
    }
}
