﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kritner.OrleansGettingStarted.Client.Helpers;
using Kritner.OrleansGettingStarted.GrainInterfaces;
using Orleans;

namespace Kritner.OrleansGettingStarted.Client.OrleansFunctionExamples
{
    public class HelloWorld : IOrleansFunction
    {
        public string Description => "Demonstrates the most basic Orleans function of 'Hello World'.";

        public async Task PerformFunction(IClusterClient clusterClient)
        {
            var grain = clusterClient.GetGrain<IHelloWorld>(Guid.NewGuid());
            Console.WriteLine("Hello! What should I call you?");
            var name = Console.ReadLine();

            Console.WriteLine(await grain.SayHello(name));

            ConsoleHelpers.ReturnToMenu();
        }
    }
}
