using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using ZeroDefects.Commands.AddInstruction;
using ZeroDefects.DBUtility.Models;
using ZeroDefects.Domain.Interfaces;
using ZeroDefects.Infrastructure.Configuration;
using ZeroDefects.Infrastructure.Data;
using ZeroDefects.Infrastructure.Data.Repositories;

namespace ZeroDefects.Infrastructure;

public static class ApplicationStartup
{
    public static IServiceCollection BootstrapApp(this IServiceCollection services, IConfiguration configuration)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AutomapperProfile());
        });

        var mapper = mapperConfig.CreateMapper();
        return services.AddSingleton(serviceProvider =>
        {
            var settings = configuration.GetSection("InstructionsDatabase").Get<DBConfiguration>();
            var mongoClient = new MongoClient(settings.ConnectionString);
            return mongoClient.GetDatabase(settings.DatabaseName);
        }).AddSingleton<IInstructionsRepository, InstructionsRepository>()
        .AddSingleton<IUserRepository, UserRepository>()
        .AddScoped<IMediator, Mediator>()
        .AddSingleton(mapper);
         
    }
    
    
}