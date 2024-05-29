using Serilog;
using TemplateWeb.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagguer(builder.Configuration);

builder.Services.RegisterServices(builder.Configuration);

#region Configuração da Biblioteca Serilog com ElasticSearch
ElasticSearchConfigurations.ConfigureLogging();
builder.Host.UseSerilog();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Ativa o Swagguer UI
app.UseSwaggerUI(x =>
{
    //Define o local onde o arquivo de especificação da API será criado
    x.SwaggerEndpoint("/swagger/v1/swagger.json", "Documentation Template ASP.NET Core Web API com Api Key");

    //Permite que o swagguer seja acessado a partir da raiz da aplicação
    x.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
