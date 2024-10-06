using System.Reflection;
using FluentMigrator.Runner;
using GbsSystem.Server.Models.AspNetUsers;
using System;
using System.Reflection;
using System.Security.Claims;
using FluentAssertions.Common;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using GbsSystem.Server.Models.EmailService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IronPdf.License.LicenseKey = "IRONSUITE.MATEUSZ.ZIARA.GMAIL.COM.16828-D57D9C62CB-C3DM2KY-HPOPFGLCWGVU-RK5N5TEAO7NS-AOA7RKXDGWS6-6I2UT2GXZ6GZ-ZOQLZK5TXX7J-ZSKEXH4DQY7Y-WMCC4V-TJKOUNH4GU2NUA-DEPLOYMENT.TRIAL-UX4BTY.TRIAL.EXPIRES.04.NOV.2024";
builder.Services.AddControllers();
builder.Services.AddScoped<EmailService>(sp => new EmailService(
    smtpServer: "smtp.gmail.com",
    port: 587,
    fromEmail: "rentitnoreply@gmail.com",
    password: ""
));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.WithOrigins("https://localhost:5173");
            builder.AllowCredentials();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
        });
});

// LearnInfo more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<EmailService>(sp => new EmailService(
    smtpServer: "smtp.gmail.com",
    port: 587,
    fromEmail: "rentitnoreply@gmail.com",
    password: "fjes lzgl haqx oegi"

));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
});
builder.Services.AddFluentMigratorCore() // Move FluentMigrator registration here
    .ConfigureRunner(c =>
    {
        c.AddSqlServer2016()
            .WithGlobalConnectionString("Server=localhost\\SQLEXPRESS;Database=Hackaton;Integrated Security=SSPI;Application Name=Hackaton; TrustServerCertificate=true;")
            .ScanIn(Assembly.GetExecutingAssembly()).For.All();
    })
    .AddLogging(config => config.AddFluentMigratorConsole());
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(
        "Server=localhost\\SQLEXPRESS;Database=Hackaton;Integrated Security=SSPI;Application Name=Hackaton; TrustServerCertificate=true;"));

builder.Services.AddIdentityApiEndpoints<AspNetUsers>()
    .AddEntityFrameworkStores<DataContext>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var migrator = scope.ServiceProvider.GetService<IMigrationRunner>();

if (migrator != null)
{
    migrator.ListMigrations();
    migrator.MigrateUp();
}
else
{
    throw new Exception("Migration fault");
}
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.MapIdentityApi<AspNetUsers>();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();

class DataContext : IdentityDbContext<AspNetUsers>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options){}
}