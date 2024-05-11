using Microsoft.OpenApi.Models;
using System.Reflection;

namespace TemplateWebApiKey.Api.Configurations
{
    /// <summary>
    /// Classe de configuração e inicialização da biblioteca Swagguer.
    /// </summary>
    public static class SwagguerConfigurations
    {
        public static void ConfigureSwagguer(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            //Especificação da API
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Template ASP.NET Core Web API com Api Key",
                    Version = "v1",
                    Description = "Um exemplo de aplicação ASP.NET Core Web API que faz a autorização e configuração por meio de Api Key.",
                    TermsOfService = new Uri("https://swagger.io/license/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Michael Viveiros",
                        Email = "michaelviveiros@outlook.com",
                        Url = new Uri("https://github.com/michaelviveiros")
                    }
                });

                x.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Informe uma chave válida",
                    Name = "api_key",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "ApiKeyScheme"
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "ApiKey"
                            },

                            In = ParameterLocation.Header
                        },
                        new string[]{}
                    }
                });

                //Permite a adição de comentários no Swagguer tornando a API mais detalhada.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
            });
        }
    }
}
