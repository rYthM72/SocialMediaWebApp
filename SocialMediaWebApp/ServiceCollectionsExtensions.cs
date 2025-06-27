using SocialMediaWebApp.Repository;

namespace SocialMediaWebApp
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();

            return services;
        }
    }
}
