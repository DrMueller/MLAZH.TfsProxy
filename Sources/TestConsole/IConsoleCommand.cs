using System;
using System.Threading.Tasks;

namespace Mmu.Mlazh.TfsProxy.TestConsole
{
    public interface IConsoleCommand
    {
        string Description { get; }
        ConsoleKey Key { get; }

        Task ExecuteAsync();
    }
}