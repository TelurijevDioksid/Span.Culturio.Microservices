using Microsoft.EntityFrameworkCore;
using Span.Culturio.Core;
using Span.Culturio.Subscriptions.Data;
using Span.Culturio.Subscriptions.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterApiServices(builder.Configuration.GetSection("Jwt:Key").Value);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISubscriptionService, SubscriptionsService>();
builder.Services.AddScoped<IPackageService, PackageService>();

builder.Services.AddHttpClient("api");

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
