namespace AtFileshare.Infrastructure
{
    using AtFileshare.Application.Common.Interfaces.Auth;
    using AtFileshare.Application.Common.Interfaces.Persistence;
    using AtFileshare.Application.Common.Interfaces.Services;
    using AtFileshare.Infrastructure.Auth;
    using AtFileshare.Infrastructure.Persistence;
    using AtFileshare.Infrastructure.Persistence.Repositories;
    using AtFileshare.Infrastructure.Services;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddDbContext<AtFileshareDbContext>(options =>
                options.UseSqlServer());
            services.AddAuth(configuration);
            services.AddFileSystem(configuration);
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }

        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSettings);

            services.AddSingleton(Options.Create(jwtSettings));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                });

            return services;
        }

        public static IServiceCollection AddFileSystem(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.Configure<FileSystemConfiguration>(
                configuration.GetSection(FileSystemConfiguration.SectionName));
            services.AddSingleton<IFileSystemProvider, FileSystemProvider>();

            return services;
        }
    }
}
