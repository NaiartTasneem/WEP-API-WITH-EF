﻿using DIcrud.CustomExc;
using DIcrud.Filters;
using DIcrud.Models;
using DIcrud.Repo;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace DIcrud
{
    public static class serveciss
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerGen();

         //  services.AddIdentity<IdentityUser, IdentityRole>();
           services.AddScoped<IUserRepo, UserRepo>();
           services.AddScoped<IPostRepo, PostRepo>();
            services.AddScoped<AppRole>();
        
        }
        /*public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
       */
       
    }
}
