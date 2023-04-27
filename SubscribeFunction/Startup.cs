using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SubscribeSDK.DAO;

[assembly: FunctionsStartup(typeof(SubscribeFunction.Startup))]
namespace SubscribeFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = builder.GetContext().Configuration;

            // Configure Cosmos DB
            builder.Services.AddDbContext<SubscribeContext>(options =>
            {
                options.UseCosmos(config.GetConnectionString("Subscribe"), "hello_cosmos");
            });

            builder.Services.AddHttpClient();

            //builder.Services.AddSingleton<IMyService>((s) => {
            //    return new MyService();
            //});

            //builder.Services.AddSingleton<ILoggerProvider, MyLoggerProvider>();
        }

        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            // Configure app configuration


        }
    }
}
