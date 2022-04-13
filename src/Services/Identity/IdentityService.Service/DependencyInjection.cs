using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using IdentityService.Application.Repositories;

namespace IdentityService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection IdentityServiceDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(ILoginRepository), typeof(LoginRepository));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
