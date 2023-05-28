using System.Text.Json.Serialization;
using AutoMapper;
using Galytix.Api.Configuration;
using Galytix.Api.DataAccess;
using Galytix.Api.Extensions;
using Galytix.Api.Middleware;
using Galytix.Api.Model.Profiles;
using Galytix.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add infrastructure
builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.DefaultIgnoreCondition = 
            JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCaching();

// Add settings
builder.Services.RegisterAndValidateSettings<ImportSettings>("ImportSettings");

// Run data import
var config = builder.Configuration.GetSection("ImportSettings").Get<ImportSettings>();
var context = DataImporter.Import(config);
builder.Services.AddSingleton(context);


// Add services
builder.Services.AddSingleton<ISerializationService, SerializationService>();
builder.Services.AddSingleton<IGwpDataRepository, GwpDataRepository>();
builder.Services.AddSingleton<IGwpDataService, GwpDataService>();

// Add mapping profiles
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile<AverageGwpProfile>();
});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

app.UseMiddleware<ApiGlobalExceptionMiddleware>();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseResponseCaching();

// Configure caching behavior
app.Use(async (context, next) =>
{
    context.Response.GetTypedHeaders().CacheControl =
        new Microsoft.Net.Http.Headers.CacheControlHeaderValue
        {
            Public = true,
            MaxAge = TimeSpan.FromSeconds(10)
        };

    await next();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
