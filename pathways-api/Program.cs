namespace pathways_api
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;

    public static class Program
    {
        public static void Main(string[] args)
        {
            Program.CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        }
    }
}