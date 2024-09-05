using Microsoft.EntityFrameworkCore;
using PracticeProject.Core.Implementation;
using PracticeProject.Core.Interface;
using PracticeProject.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cString = builder.Configuration.GetConnectionString("PracticeDb");

builder.Services.AddDbContext<PracticeDbContext>(option => option.UseSqlServer(cString));
builder.Services.AddScoped<ICustomerCreation, CustomerCreation>();
builder.Services.AddScoped<IProductCreation, ProductCreation>();
builder.Services.AddScoped<IMappingCreation, MappingCreation>();
builder.Services.AddScoped<IMappingUpdation, MappingUpdation>();
builder.Services.AddScoped<IProductAddEpPlus, ProductAddEpPlus>();
builder.Services.AddScoped<IProductGetEpPlus, ProductGetEpPlus>();
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