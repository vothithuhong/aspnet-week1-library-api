using AspNetWeek1.Stationery.Api.Models;
using AspNetWeek1.Stationery.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ItemService>();

builder.Services.Configure<AppSettings>(
    builder.Configuration.GetSection("AppSettings"));

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

// Endpoints
app.MapGet("/", () => Results.Ok(new { message = "Stationery API is running" }));

app.MapGet("/health", () => Results.Ok(new { status = "healthy" }));

app.MapGet("/env", () => Results.Ok(new
{
    Environment = app.Environment.EnvironmentName
}));

app.MapGet("/config", (IConfiguration config) => Results.Ok(new
{
    AppName = config["AppSettings:AppName"],
    StoreName = config["AppSettings:StoreName"]
}));

app.MapControllers();

app.Run();