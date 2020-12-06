using FirstDotNetApplication_RepositoryLayer.Implementation;
using FirstDotNetApplication_RepositoryLayer.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstDotNetApplication
{
    public static class RepositoryServiceExtension
    {
        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            services.AddScoped<IExpensivePaymentGateway, ExpensivePaymentGateway>();
            services.AddScoped<ICheapPaymentGateway, CheapPaymentGateway>();
            services.AddScoped<IPremiumPaymentService, PremiumPaymentService>();
            return services;
        }
    }
}
