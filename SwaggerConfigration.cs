using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhadimiEssa
{
    public class SwaggerConfigration : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions c)
        {
            c.SwaggerDoc("ChatApi", new OpenApiInfo { Title = "ChatApi API", Version = "v1" });
            c.SwaggerDoc("ClientApp", new OpenApiInfo { Title = "ClientApp API", Version = "v1" });
            c.SwaggerDoc("DelegetApp", new OpenApiInfo { Title = "DelegetApp API", Version = "v1" });
            c.SwaggerDoc("AuthAPI", new OpenApiInfo { Title = "Auth API", Version = "v1" });
            c.SwaggerDoc("LogicClient", new OpenApiInfo { Title = "LogicClient API", Version = "v1" });
            c.SwaggerDoc("LogicProvider", new OpenApiInfo { Title = "LogicProvider API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme."
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });

            // Set the comments path for the Swagger JSON and UI from xml file.
            var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        }
    }

    public class SwaggerUIConfiguration : IConfigureOptions<SwaggerUIOptions>
    {
        public void Configure(SwaggerUIOptions options)
        {
            options.RoutePrefix = "SwaggerPlus";
            options.SwaggerEndpoint("/swagger/ChatApi/swagger.json", "ChatApi API");
            options.SwaggerEndpoint("/swagger/ClientApp/swagger.json", "ClientApp API");
            options.SwaggerEndpoint("/swagger/DelegetApp/swagger.json", "DelegetApp API V1");
            options.SwaggerEndpoint("/swagger/AuthAPI/swagger.json", "Auth API V1");
            options.SwaggerEndpoint("/swagger/LogicClient/swagger.json", "LogicClient API V1");
            options.SwaggerEndpoint("/swagger/LogicProvider/swagger.json", "LogicProvider API V1");



        }
    }
}
