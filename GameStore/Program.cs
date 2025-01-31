using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using GameStore.DL.Interfaces;
using GameStore.DL.Repositories.MongoDb;
using GameStore.DL.Repositories;
using GameStore.DL;
using GameStore.BL.Interfaces;
using GameStore.BL.Services;
using GameStore.Models.Requests;
using FluentValidation;
using GameStore.Validators;
using GameStore.Models.Configurations;
using FluentValidation.AspNetCore;
using GameStore.MapConfig;
using GameStore.ServiceExtensions;
using Mapster;
using Serilog.Sinks.SystemConsole.Themes;
using GameStore.HealthChecks;

namespace GameStore
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            var logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(theme:
                    AnsiConsoleTheme.Code)
                .CreateLogger();

            builder.Logging.AddSerilog(logger);

            // Add services to the container.
            builder.Services
                .AddConfigurations(builder.Configuration)
                .RegisterDataLayer()
                .RegisterBusinessLayer();

            MapsterConfiguration.Configure();
            builder.Services.AddMapster();


            builder.Services
                .AddValidatorsFromAssemblyContaining<GetAllGamesByPublisherRequestValidator>();
            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHealthChecks();

            builder.Services.AddHealthChecks()
                .AddCheck<CustomHealthChecks>("Custom");

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapHealthChecks("/Sample");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();



        }
    }
}
