using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Attendance.Application.Repositories;
using Microsoft.Extensions.Configuration;

namespace Attendance.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();

            //MediatR Pipeline Behavior 
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
