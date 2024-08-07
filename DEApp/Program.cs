

using BankLoanManagement.Services;
using DealerPortalApp.Interfaces;
using DEApp.Data;
using DEApp.Interfaces;
using DEApp.Models;
using DEApp.Repositories;
using DEApp.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DEApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<DeappContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

           

            builder.Services.AddScoped<IApplicantService, ApplicantService>();
            builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository<string, User>, UserRepository>();
            builder.Services.AddScoped<ITokenService, TokenService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(opts =>
            {
                opts.AddPolicy("Cors", options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseCors("Cors");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
