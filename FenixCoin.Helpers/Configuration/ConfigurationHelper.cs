using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FenixCoin.Helpers.Configuration
{
    public static class ConfigurationHelper
    {
        public static void ConfigureAuthentication(this IServiceCollection services, string secretKey)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new()
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey))
                };
            });
        }

        public static void ConfigureCORSPOlicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                    policy =>
                    {
                        policy.WithOrigins()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
        }
    }
}
