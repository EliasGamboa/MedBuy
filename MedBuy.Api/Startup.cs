using System;
using AutoMapper;
using MedBuy.Domain.Interfaces;
using MedBuy.Infraestructure.Data;
using MedBuy.Infraestructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using MedBuy.Infraestructure.Filters;
using MedBuy.Application.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MedBuy.Domain.Entities;
using System.Text;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authorization;

namespace MedBuy.Api
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AnotherPolicy",
                builder =>
                {
                    builder.WithOrigins("https://localhost:44389")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers(options =>
                options.Filters.Add<GlobalExceptionFilter>()
               );

            services.AddDbContext<MedBuyContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MedBuyConnection"))
            );

            services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MedBuyContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<IProductoRepository, ProductoRepository>();
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddMvc().AddFluentValidation(options => 
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(opt =>
           {
               opt.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AppSettings:Token")),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           })
           .AddIdentityCookies(o => { });

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });

            services.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
                    JwtBearerDefaults.AuthenticationScheme);

                defaultAuthorizationPolicyBuilder =
                    defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();

                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
