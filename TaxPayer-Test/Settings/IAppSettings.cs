using Microsoft.Extensions.DependencyInjection;

namespace TaxPayer.Settings
{
    public interface IAppSettings
    {
        void Register(IServiceCollection services);
        string getDefaultConnection();
    }
}
