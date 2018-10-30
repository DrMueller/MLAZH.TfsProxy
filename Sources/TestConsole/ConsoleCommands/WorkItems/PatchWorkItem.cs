using System;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.AzureFunctions.WorkItems.Functions;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Newtonsoft.Json;

namespace Mmu.Mlazh.TfsProxy.TestConsole.ConsoleCommands.WorkItems
{
    public class PatchWorkItem : IConsoleCommand
    {
        public string Description { get; } = "Patch WorkItem";
        public ConsoleKey Key { get; } = ConsoleKey.D1;

        public async Task ExecuteAsync()
        {
            var itm = await PatckWorkItem.PatchAsync(null, null);
            Console.WriteLine(JsonConvert.SerializeObject(itm));
        }
    }
}