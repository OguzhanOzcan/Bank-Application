using System;   
using Prometheus;
using ServerApp.Data;
using ServerApp.Helpers;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ServerApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ServerApp.Repositories.Interfaces;
using ServerApp.Services.Implementations;
using Microsoft.Extensions.Configuration;
using ServerApp.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;


namespace ServerApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<JwtHelper>();
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.AddSingleton<IEventService, EventService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICreditRepository, CreditRepository>();
            services.AddScoped<ICreditService, CreditService>();
            services.AddScoped<ICreditApplicationRepository, CreditApplicationRepository>();
            services.AddScoped<ICreditApplicationService, CreditApplicationService>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            services.AddAuthentication("Bearer")
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                            System.Text.Encoding.ASCII.GetBytes("YourVeryStrongSecretKey123!")
                        )
                    };
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BankApp API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("AllowAngular");

            app.UseMiddleware<GlobalExceptionMiddleware>();
            app.UseMiddleware<ApiResponseTimeMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BankApp API V1");
                c.RoutePrefix = "swagger";
            });

            app.UseHttpMetrics();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapMetrics();
            });
        }
    }
}
