using FenixCoin.DataAccess.Context;
using FenixCoin.Shared.Configuration;
using Microsoft.EntityFrameworkCore;
using FenixCoin.Helpers.DependencyInjection;
using FenixCoin.Helpers.Configuration;
using FenixCoin.Mappers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var fenixSettings = builder.Configuration.GetSection("FenixAppSettings");
builder.Services.Configure<FenixAppSettings>(fenixSettings);
FenixAppSettings fenixAppSettings = fenixSettings.Get<FenixAppSettings>();

builder.Services.AddDbContext<FenixDbContext>(options => options.UseSqlServer(fenixAppSettings.ConnectionString));

builder.Services.InjectRepositories();
builder.Services.InjectServices();

builder.Services.AddAutoMapper(typeof(FenixMapper).Assembly);

builder.Services.ConfigureAuthentication(fenixAppSettings.SecretKey);

builder.Services.ConfigureCORSPOlicy();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
