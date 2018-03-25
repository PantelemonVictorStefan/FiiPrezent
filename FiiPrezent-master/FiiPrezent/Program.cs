using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace FiiPrezent
{
    class Program
    {
        static void Main(string[] args)
        {
            var variable = 0;

            var host = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
            
            host.Run();
        }
    }
 }
