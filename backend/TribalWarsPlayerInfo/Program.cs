using TribalWarsPlayerInfo.Services;
using TribalWarsPlayerInfo.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddScoped<IApiGateway, ApiGateway>()
    .AddScoped<IHtmlManipulator, HtmlManipulator>()
    .AddScoped<IPlayerInfoExtractorService, PlayerInfoExtractorService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyHeader()
                  .AllowAnyOrigin()
                  .AllowAnyMethod());
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
