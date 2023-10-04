using CommunityToolkit.Mvvm.DependencyInjection;
using ERGenerator.Application;
using ERGenerator.DataAccess.Repositories;
using ERGenerator.UseCase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static ERGenerator.AppSettings;

namespace TestProject
{
    internal class DIFixture
    {
        public DIFixture()
        {
            var services = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            services.Configure<ERServiceSettings>(configuration.GetSection("ERServiceSettings"));

            services.AddTransient<IRoslynParser, RoslynParser>();
            services.AddTransient<IClassInfoUseCase, ClassInfoUseCase>();
            services.AddTransient<IERService, ERService>();
            services.AddLogging();

            var provider = services.BuildServiceProvider();
          
            Ioc.Default.ConfigureServices(provider);
        }
    }
}
