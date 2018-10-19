using System;
using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.Mlazh.TfsProxy.TestConsole
{
    public static class ConsoleCommansContainer
    {
        private static IReadOnlyCollection<IConsoleCommand> _commands;

        public static void Start()
        {
            _commands = ProvisioningServiceSingleton.Instance.GetAllServices<IConsoleCommand>();
            ListenForInputs();
        }

        private static void ListenForInputs()
        {
            ShowCommands();
            Console.WriteLine();

            var keyInfo = Console.ReadKey();

            var command = _commands.FirstOrDefault(f => f.Key == keyInfo.Key);
            if (command == null)
            {
                Console.WriteLine("No Command found !");
            }

            Console.WriteLine("Executing..");
            command.ExecuteAsync();

            ListenForInputs();
        }

        private static void ShowCommands()
        {
            _commands.ForEach(command => Console.WriteLine($"{command.Key} - {command.Description}"));
        }
    }
}