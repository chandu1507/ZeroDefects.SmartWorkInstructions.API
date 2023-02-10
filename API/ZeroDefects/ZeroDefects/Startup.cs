using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using System.Reflection;
using MediatR;
using ZeroDefects.Infrastructure.Data;
using ZeroDefects.Infrastructure;
using ZeroDefects.Commands.AddInstruction;
using ZeroDefects.Queries.GetInstructions;
using ZeroDefects.Infrastructure.Configuration;
using ZeroDefects.Commands.CreateUser;
using ZeroDefects.Queries.GetUsers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Configuration;

namespace ZeroDefects.API
{
    internal static class Startup
    {
        internal static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            
            builder.Services.Configure<DBConfiguration>(
    builder.Configuration.GetSection("InstructionsDatabase"));
            builder.Services
                .AddCors()
                .BootstrapApp(builder.Configuration)
                .AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
                .AddJsonOptions(jsonOptions => jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null);
            builder.Services
                .AddAuthentication(x=>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                }
                )
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey=true,
                        IssuerSigningKey= new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JwtKey").Value.ToString()))
                    };
                });
            builder.Services
                .AddSwagger();

            builder.Services.AddAutoMapper(typeof(AutomapperProfile).GetTypeInfo().Assembly);
            builder.Services.AddMediatR(typeof(CreateInstructionCommand));
            builder.Services.AddMediatR(typeof(GetInstructionsQuery));
           
            return builder;
        }

        internal static WebApplication Configure(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI();

            app.MapControllers();

            return app;
        }

        private static IServiceCollection AddSwagger(this IServiceCollection services) =>
            services
                .AddEndpointsApiExplorer()
                .AddSwaggerGen(c =>
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Config API",
                        Description = "ASP.NET Core Web API"
                    }));

        private static IServiceCollection AddCors(this IServiceCollection services) =>
            services.AddCors(o => o.AddDefaultPolicy(builder => builder
                .WithOrigins(                   
                    "http://localhost:4200"
                )
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()));
    }
}