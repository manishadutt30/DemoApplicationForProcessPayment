using FirstDotnetApplication_ServiceLayer.Implementation;
using FirstDotnetApplication_ServiceLayer.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace FirstDotNetApplication
{
    public static class BusinessServiceExtension
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            services.AddScoped<IProcessPayment, ProcessPayment>();
            services.AddScoped<IConversionModelToEntity, ConversionModelToEntity>();
            services.AddScoped<IGetAmount, LessThanTwentyZero>();
            services.AddScoped<IGetAmount, BetweenTwentAndFiveHundredEuro>();
            services.AddScoped<IGetAmount, MoreThanFiveHundredEuro>();
            return services;
        }
    }
}
