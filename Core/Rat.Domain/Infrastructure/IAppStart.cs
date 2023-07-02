using Microsoft.Extensions.DependencyInjection;

namespace Rat.Domain.Infrastructure
{
    public partial interface IAppStart
    {
        void ConfigureServices(IServiceCollection services);

        int Order { get; }
    }
}
