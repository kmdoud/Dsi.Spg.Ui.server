using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Dsi.Spg.Ui.Data;
using Dsi.Spg.Ui.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var AppAccess = "_AppAccess";

builder.Services.AddControllers();

var connStr = "SpgContext";
builder.Services.AddDbContext<SpgDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString(connStr));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(x => {
    x.AddPolicy(name: AppAccess,
        builder => {
            builder.WithOrigins("http://localhost", "http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
        }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(AppAccess);

app.UseAuthorization();

app.MapControllers();

app.Run();
