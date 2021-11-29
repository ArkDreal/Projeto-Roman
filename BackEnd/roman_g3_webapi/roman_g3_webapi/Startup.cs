using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace roman_g3_webapi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
 
               .AddControllers()
               .AddNewtonsoftJson(options =>
               {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
               });

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Roman.webApi", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services
                // Define a forma de autentica??o
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                 .AddJwtBearer("JwtBearer", options =>
                 {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         // define que o issuer ser? validado
                         ValidateIssuer = true,

                         // define que o audience ser? validado
                         ValidateAudience = true,

                         // define que o tempo de vida ser? validado
                         ValidateLifetime = true,

                         // forma de criptografia e a chave de autentica??o
                         IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("roman-chave-autenticacao")),

                         // verifica o tempo de expira??o do token
                         ClockSkew = TimeSpan.FromMinutes(30),

                         // define o nome da issuer, de onde est? vindo
                         ValidIssuer = "roman.webApi",

                         // define o nome da audience, para onde est? indo
                         ValidAudience = "roman.webApi"
                     };
                 });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Roman.webApi");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
