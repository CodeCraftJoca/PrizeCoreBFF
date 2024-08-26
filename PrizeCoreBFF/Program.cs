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
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Sorteios",
        Version = "v1",
        Description = "Uma API para gerenciar sorteios e termos e condições.",
        Contact = new OpenApiContact
        {
            Name = "João Ribeiro",
            Email = "joao.ribeiro1@outlook.com.br",
            Url = new Uri("https://github.com/CodeCraftJoca")
        }
    });

    // Inclui o arquivo XML para a API
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
    else
    {
        Console.WriteLine($"Arquivo XML não encontrado: {xmlPath}");
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
