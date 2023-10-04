using ERGenerator.Application;
using ERGenerator.DataAccess.Repositories;
using ERGenerator.UseCase;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static ERGenerator.AppSettings;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) => 
    {
        var configuration = hostContext.Configuration;
        services.Configure<ERServiceSettings>(configuration.GetSection("ERServiceSettings"));

        services.AddTransient<IRoslynParser, RoslynParser>();
        services.AddTransient<IClassInfoUseCase, ClassInfoUseCase>();
        services.AddTransient<IERService, ERService>();
    })
    .Build();

var service = host.Services.GetRequiredService<IERService>();
service.Execute();