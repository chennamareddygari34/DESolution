using BankLoanManagement.Services;
using DealerPortalApp.Interfaces;
using DEApp.Interfaces;
using DEApp.Models;
using DEApp.Repositories;
using DEApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DEApp.Configuration
{
    public static class ServiceConfiguration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // Register services and repositories

            services.AddScoped<IApplicantService, ApplicantService>();
            services.AddScoped<IApplicantRepository, ApplicantRepository>();
            
            //Vendor
            services.AddScoped<IVendorService, VendorService>();
            services.AddScoped<IVendorRepository<int, Vendor>, VendorRepository>();

            //Users
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository<string, User>, UserRepository>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}