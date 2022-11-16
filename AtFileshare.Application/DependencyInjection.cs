namespace AtFileshare.Application
{
    using AtFileshare.Application.Services.Auth;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
