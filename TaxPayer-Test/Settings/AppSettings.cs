using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaxPayer.Database.Context;
using TaxPayer.Model;
using TaxPayer.Repository.TaxPayer;
using TaxPayer.Service.IR;
using TaxPayer.Service.TaxPayer;
using TaxPayer.ViewModel;

namespace TaxPayer.Settings
{
    public class AppSettings : IAppSettings
    {
        private readonly IConfiguration _config;
        private readonly string _defaultConnection;

        public AppSettings(IConfiguration config)
        {
            _config = config;

            _defaultConnection = _config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
        }

        public string getDefaultConnection()
        {
            return _defaultConnection;
        }

        public void Register(IServiceCollection services)
        {
            #region Mapper
            services.AddSingleton<IMapper>(new Mapper(new MapperConfiguration(mapper => {
                ViewModelToModel(mapper);
                ModelToViewModel(mapper);
            })
            ));
            #endregion

            #region Service
            services.AddScoped<IPayerService, PayerService>();
            services.AddScoped<IIRService, IRService>();
            #endregion

            #region Repository
            services.AddScoped<IPayerRepository, PayerRepository>();
            #endregion

            #region Database
            services.AddDbContext<DbAppContext>(options => options.UseSqlServer(this.getDefaultConnection()));
            #endregion
        }

        private static void ViewModelToModel(IMapperConfigurationExpression mapper)
        {
            mapper.CreateMap<PayerViewModel, Payer>();            
        }

        private static void ModelToViewModel(IMapperConfigurationExpression mapper)
        {
            mapper.CreateMap<Payer, PayerViewModel>();
        }
    }
}
