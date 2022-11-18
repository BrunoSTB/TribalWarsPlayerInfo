using TribalWarsPlayerInfo.Services;
using TribalWarsPlayerInfo.Tools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddScoped<IApiGateway, ApiGateway>()
    .AddScoped<IHtmlManipulator, HtmlManipulator>()
    .AddScoped<IPlayerInfoExtractorService, PlayerInfoExtractorService>();

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

app.Run();
