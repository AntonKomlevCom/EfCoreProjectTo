using Microsoft.Extensions.DependencyInjection;
using RugbyLeague.Repositories;
namespace RugbyLeague.Configuration
{
    public static class RepositoriesConfigurationExtensions
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            return services;
        }
    }
}
