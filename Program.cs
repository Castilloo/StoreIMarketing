using IMarketing.Interfaces;
using IMarketing.Repositories;
using Microsoft.EntityFrameworkCore;
using TiendaIMark.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(opt => {
    opt.AddPolicy("AllowOrigin", builder => 
        builder.WithOrigins("http://localhost:8080"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IMarketingContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("imarketingConnection")));

builder.Services.AddTransient<IStoreRepository, StoreRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
