using InstaResume.GenAI.WebApi.Configuration;
using InstaResume.GenAI.WebApi.Configuration.Interface;
using InstaResume.GenAI.WebApi.Services;
using InstaResume.GenAI.WebApi.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.Secret.json", optional: true, reloadOnChange: true);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register services
builder.Services.AddSingleton<IConfigHelper, ConfigHelper>();
builder.Services.AddSingleton<IDescriptionGeneratorService, DescriptionGeneratorService>();

builder.Services.AddHealthChecks();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();
