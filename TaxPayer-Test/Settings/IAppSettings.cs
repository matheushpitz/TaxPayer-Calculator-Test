using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxPayer.Settings
{
    public interface IAppSettings
    {
        void Register(IServiceCollection services);
    }
}
