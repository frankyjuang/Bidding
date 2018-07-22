using Bidding.Framework;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Bidding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateWebHostBuilder(args).Build().Run();

            var game = new GamePlay();
            game.Start();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
