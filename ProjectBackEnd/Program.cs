using DomainLayer.ApplicationDbContext;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepositoryFolder;
using RepositoryLayer.RepositoryFolder;
using ServiceLayer.IServiceFolder;
using ServiceLayer.ServiceFolder;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<appDbContext>(opt => opt.UseSqlServer("Server=DESKTOP-BQH0PBP;Database=TaskManagement1;Trusted_Connection=True;Encrypt=false;"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IRepository1<>), typeof(Repository<>));
builder.Services.AddScoped<IService<taskStruct>, Service1>();


builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corspolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
