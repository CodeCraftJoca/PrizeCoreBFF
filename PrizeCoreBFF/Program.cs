using Microsoft.OpenApi.Models;
using PrizeCoreBFF.Application.Interfaces;
using PrizeCoreBFF.Application.Mapping;
using PrizeCoreBFF.Application.UseCases;
using PrizeCoreBFF.ExternalServices;
using PrizeCoreBFF.ExternalServices.InterfaceServices;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(DTOMapping));
builder.Services.AddScoped<IGetPrizeUseCase, GetPrizeUseCase>();
builder.Services.AddScoped<ManualDTOMapping>();
builder.Services.AddScoped<ManualDTOVibeMapping>();
builder.Services.AddScoped<ManualDTOTermsMapping>();

builder.Services.AddHttpClient<IPrizeDrawConsumerService, PrizeDrawConsumerService>(client =>
{
    client.BaseAddress = new Uri("https://api.example.com/"); // Configure a URL base do servi�o externo
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    // Informa��es do documento Swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Minha API",
        Version = "v1",
        Description = "Uma API para demonstrar o Swagger e a documenta��o XML",
        Contact = new OpenApiContact
        {
            Name = "Seu Nome",
            Email = "seu.email@example.com"
        }
    });

    // Inclus�o dos arquivos XML de coment�rios
    var apiXmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var apiXmlPath = Path.Combine(AppContext.BaseDirectory, apiXmlFile);
    if (File.Exists(apiXmlPath))
    {
        options.IncludeXmlComments(apiXmlPath);
    }
    else
    {
        Console.WriteLine($"Arquivo XML da API n�o encontrado: {apiXmlPath}");
    }

    var appXmlFile = "PrizeCoreBFF.Application.xml"; // Nome do arquivo XML da aplica��o
    var appXmlPath = Path.Combine(AppContext.BaseDirectory, appXmlFile);
    if (File.Exists(appXmlPath))
    {
        options.IncludeXmlComments(appXmlPath);
    }
    else
    {
        Console.WriteLine($"Arquivo XML da Aplica��o n�o encontrado: {appXmlPath}");
    }

});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Sorteios v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
