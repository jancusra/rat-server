using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rat.Domain.Options;

namespace Rat.Framework
{
    public static class StartupRegistrationExtensions
    {
        public static void AddApplicationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            var usersSection = configuration.GetSection("User");
            var usersOptions = new UserOptions();
            usersSection.Bind(usersOptions);
            services.Configure<UserOptions>(usersSection);
        }
    }
}
