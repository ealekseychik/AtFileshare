namespace AtFileshare.Infrastructure
{
    using AtFileshare.Application.Common.Interfaces.Auth;
    using AtFileshare.Application.Common.Interfaces.Persistence;
    using AtFileshare.Application.Common.Interfaces.Services;
    using AtFileshare.Infrastructure.Auth;
    using AtFileshare.Infrastructure.Persistence;
    using AtFileshare.Infrastructure.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
