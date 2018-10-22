﻿using StructureMap;

namespace Mmu.Mlazh.TfsProxy.TestConsole
{
    public class TestConsoleRegistry : Registry
    {
        public TestConsoleRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<TestConsoleRegistry>();
                    scanner.AddAllTypesOf<IConsoleCommand>();
                    scanner.WithDefaultConventions();
                });

            For<IConsoleCommand>().Singleton();
        }
    }
}