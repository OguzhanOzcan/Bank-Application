using ServerApp.Data;
using ServerApp.Helpers;
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
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<JwtHelper>();

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

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
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("AllowAngular");

            app.UseAuthentication(); 
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
