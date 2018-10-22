using System;
using System.Collections.Generic;
using System.Linq;
using Mmu.Mlazh.TfsProxy.TestConsole.Common.Infrastructure.ServiceProvisioning;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.Mlazh.TfsProxy.TestConsole
{
    public static class ConsoleCommansContainer
    {
        private static IReadOnlyCollection<IConsoleCommand> _commands;

        public static void Start()
        {
            _commands = AppProvisioningService
                .GetAllServices<IConsoleCommand>()
                .OrderBy(f => f.Key)
                .ToList();

            ListenForInputs();
        }

        private static void ListenForInputs()
        {
            ShowCommands();
            Console.WriteLine();

            var keyInfo = Console.ReadKey(true);

            var command = _commands.FirstOrDefault(f => f.Key == keyInfo.Key);
            if (command == null)
            {
                Console.WriteLine($"No Command for {keyInfo.Key} found !");
                ListenForInputs();
            }

            Console.WriteLine($"Executing {keyInfo.Key} ..");
            command.ExecuteAsync();

            ListenForInputs();
        }

        private static void ShowCommands()
        {
            _commands.ForEach(command => Console.WriteLine($"{command.Key} - {command.Description}"));
        }
    }
}