/*
 * GimuFrontier: An experimental Brave Frontier emulator written in C# with ASP.Net
 * 
 * Copyright (C) 2022 Arves100
 */
using gimufrontier;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis.Extensions.Core.Abstractions;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.System.Text.Json;

Console.WriteLine("--------------------------------------------------------------------");
Console.WriteLine("   GimuFrontier: An experimental Brave Frontier emulator");
Console.WriteLine("                 Copyright (C) 2022 Arves100");
Console.WriteLine("--------------------------------------------------------------------");

var builder = WebApplication.CreateBuilder(args);
var cfg = builder.Configuration;

var mySqlString = cfg.GetConnectionString("Database");
var sqlServerVer = ServerVersion.AutoDetect(mySqlString);
var redisString = cfg.GetConnectionString("Redis").Split(";").ToDictionary(x => x.Substring(0, x.LastIndexOf("=")), x => x.Substring(x.LastIndexOf("=") + 1));

var redisCfg = new RedisConfiguration
{
    AbortOnConnectFail = true,
    KeyPrefix = "_bf_",
    Hosts = new[]
    {
        new RedisHost()
        {
            Host = redisString["Server"],
            Port = redisString.ContainsKey("Port") ? int.Parse(redisString["Port"]) : 6379
        },
    },
    Name = "GimuFrontier-Redis",
    Ssl = redisString.ContainsKey("Ssl") ? bool.Parse(redisString["Ssl"]) : false,
    Password = redisString.ContainsKey("Password") ? redisString["Password"] : null,
};

builder.Services.AddControllers().AddJsonOptions(j =>
    j.JsonSerializerOptions.IncludeFields = true
);

builder.Services.AddDbContext<GimuDbContext>(options => options
        .UseMySql(mySqlString, sqlServerVer)
#if DEBUG
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
#endif
);

#if DEBUG
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
#endif

builder.Services.AddStackExchangeRedisExtensions<SystemTextJsonSerializer>(redisCfg);

builder.Services.AddControllers();

var app = builder.Build();

app.UseRedisInformation();

app.UseAuthorization();

app.MapControllers();

app.Run();
