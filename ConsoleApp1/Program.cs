// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NBL.BPA.Data;
using NBL.BPA.DataLoader;


using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<App>().Run(args);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

IHostBuilder CreateHostBuilder(string[] strings)
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddDbContext<ApplicationDbContext>(
                                                 dbContextOptions => dbContextOptions.UseSqlServer("Data Source=01PF3R5R5Z;Database=NBLDb;Integrated Security=True;MultipleActiveResultSets=true; Encrypt=False"));
           // services.AddDbContext<ApplicationDbContext>();
            services.AddSingleton<IRepository, Repository>();
            services.AddSingleton<IProcessor, Processor>();
            services.AddSingleton<App>();
        })
        .ConfigureAppConfiguration(app =>
        {
            app.AddJsonFile("appsettings.json");
        });
}