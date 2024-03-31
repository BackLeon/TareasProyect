using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Infrastructure.Repository.Abstract;
using Infrastructure.Repository.Implemetation;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DepContainer
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();

            return services;
        }
    }
}