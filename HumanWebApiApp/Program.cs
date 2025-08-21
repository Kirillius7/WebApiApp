using HumanWebApiApp;
using HumanWebApiApp.Model;
using HumanWebApiApp.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var stringConfiguration = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HumanDbContext>(options =>
options.UseMySql(stringConfiguration, ServerVersion.AutoDetect(stringConfiguration)));
builder.Services.AddScoped<IHumanRepository, HumanRepository>();
var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
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
