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
    client.BaseAddress = new Uri("https://api.example.com/"); // Configure a URL base do serviço externo
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    // Informações do documento Swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Minha API",
        Version = "v1",
        Description = "Uma API para demonstrar o Swagger e a documentação XML",
        Contact = new OpenApiContact
        {
            Name = "Seu Nome",
            Email = "seu.email@example.com"
        }
    });

    // Inclusão dos arquivos XML de comentários
    var apiXmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var apiXmlPath = Path.Combine(AppContext.BaseDirectory, apiXmlFile);
    if (File.Exists(apiXmlPath))
    {
        options.IncludeXmlComments(apiXmlPath);
    }
    else
    {
        Console.WriteLine($"Arquivo XML da API não encontrado: {apiXmlPath}");
    }

    var appXmlFile = "PrizeCoreBFF.Application.xml"; // Nome do arquivo XML da aplicação
    var appXmlPath = Path.Combine(AppContext.BaseDirectory, appXmlFile);
    if (File.Exists(appXmlPath))
    {
        options.IncludeXmlComments(appXmlPath);
    }
    else
    {
        Console.WriteLine($"Arquivo XML da Aplicação não encontrado: {appXmlPath}");
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
