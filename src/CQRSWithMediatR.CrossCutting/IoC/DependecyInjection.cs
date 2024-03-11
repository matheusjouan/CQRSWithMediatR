using CQRSWithMediatR.Application.Features.Member.Commands;
using CQRSWithMediatR.Domain.Interface;
using CQRSWithMediatR.Infra.Context;
using CQRSWithMediatR.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Data;
using MySqlConnector;
using FluentValidation;
using System.Reflection;
using CQRSWithMediatR.Application.Features.Validaton;

namespace CQRSWithMediatR.CrossCutting.IoC;
public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddSingleton<IDbConnection>(provider =>
        {
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        });

        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IMemberDapperRepository, MemberDapperRepository>();

        return services;
    }

    public static IServiceCollection AddMediatrServices(this IServiceCollection services)
    {
        var myHandlers = AppDomain.CurrentDomain.Load("CQRSWithMediatR.Application");
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(myHandlers);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.Load("CQRSWithMediatR.Application"));

        return services;
    }
}
