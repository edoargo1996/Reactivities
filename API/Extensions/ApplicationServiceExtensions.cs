using System.Collections.Generic;
using Application.Activities;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config){
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
            });
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors(opt=>
            {
                opt.AddPolicy("CorsPolicy", policy=>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");     //stiamo permettendo che sul sito nostro tutti i metodi e gli header che vengono dalla porta 3000 siano utilizzabili
                });
            });
            
            services.AddMediatR(typeof(List.Handler).Assembly);                                         //creiamo un nuovo service per il mediator, e gli diciamo dove trovarlo
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);                                   //aggiungiamo il servizio per l'automapper

            return services;
        }
    }
}