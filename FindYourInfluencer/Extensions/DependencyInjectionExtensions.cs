using FYI.Data.Services.ManageCustomer;
using FYI.Data.Services.ManageInfluencer;
using Microsoft.Extensions.DependencyInjection;
namespace FindYourInfluencer.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            // Register all your scoped services here
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IInfluencerService, InfluencerService>();
        }
    }
}
