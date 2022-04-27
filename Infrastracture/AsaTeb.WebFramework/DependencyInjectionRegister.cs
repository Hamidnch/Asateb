using AsaTeb.Application.Technologies.Queries;
using AsaTeb.Application.Technologies.Repositories;
using AsaTeb.Persistence.Technologies;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AsaTeb.Application.FacadePattern;

namespace AsaTeb.WebFramework
{
    public static class DependencyInjectionRegister
    {
        public static IServiceCollection RegisterAsaTebServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(GetAllTechnologiesQuery).GetTypeInfo().Assembly);
            services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            services.AddScoped<IAsaTebService, AsaTebService>();

            return services;
        }

    }
}