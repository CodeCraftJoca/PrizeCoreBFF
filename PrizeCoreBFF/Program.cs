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
        Title = "PrizeDrawBFF",
        Version = "v1",
        Description = "Uma API Backend for Frontend (BFF) para gerenciar sorteios e vibrações. Esta API oferece funcionalidades para consultar e gerenciar sorteios, números da sorte e vibes.",
        Contact = new OpenApiContact
        {
            Name = "João Carlos Ribeiro",
            Email = "joao.ribeiro1@outlook.com.br",
            Url = new Uri("https://www.linkedin.com/in/jo%C3%A3o-carlos-ribeiro-7717bb152/") 
        },
        License = new OpenApiLicense
        {
            Name = "Free License",
            Url = new Uri("https://opensource.org/licenses/MIT") 
        },
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
