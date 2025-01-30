using System.Reflection;
using System.Text.Json.Serialization;
using CartonCaps.Referral.Api.Application.Command;
using CartonCaps.Referral.Infrastructure.Abstractions;
using CartonCaps.Referral.Infrastructure.Command;
using CartonCaps.Referral.Infrastructure.Query;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CartonCaps.Referral.Api",
        Version = "v1",
        Description = "This API provides the REST endpoints to allow Carton Caps app users to refer their friends to install the Carton Caps app. " +
                     "The new feature will be powered by shareable deferred deep links, which allow the app to present a customized onboarding experience for the referred user after installing the app",
        Contact = new OpenApiContact { Name = "James Kite", Email = "james.kite@gmail.com" },
    });

    // Load XML comments
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


// Register MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateReferralHandler).Assembly));


builder.Services.AddScoped<IReferralCommandRepository, ReferralCommandRepository>();
builder.Services.AddScoped<IReferralQueryRepository, ReferralQueryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
