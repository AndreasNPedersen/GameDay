using GameDay;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.Extensions.Configuration;

using System;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseKestrel().UseUrls("http://0.0.0.0:5400");
// Add services to the container.
builder.Services.AddCors(x => x.AddPolicy("allowall",
    x=>x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string conString = "Server=172.17.0.3; Port = 3306; Database = GameData; User Id=root; Pwd = 46bd5593176e33fee9f0";
var dbServerVersion = new MariaDbServerVersion(new Version(10, 5, 4));
builder.Services.AddDbContextPool<GameContext>(options => options
        .UseMySql(
             conString,
            dbServerVersion
        )
    );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("allowall");
app.UseAuthorization();

app.MapControllers();

app.Run();
