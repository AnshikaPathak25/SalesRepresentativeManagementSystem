using System.Text;
using BusinessLayer.IService;
using BusinessLayer.Service;
using DataAccessLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.IRepository;
using RepositoryLayer.Repository;
using SalesRepManagementSystem.GlobalExceptionHandler;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISalesRepBL, SalesRepBL>();
builder.Services.AddScoped<IUserBL, UserBL>();
builder.Services.AddScoped<ISalesRepRepository, SalesRepRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Configure Serilog for file logging
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Day) // Logs to a file
    .CreateLogger();

builder.Host.UseSerilog();

//Cors configuration
builder.Services.AddCors(config =>
{
    config.AddPolicy("AngularPolicy", option =>
    {
        string angularUrl = builder.Configuration.GetSection("Origins")["Angular"]??"";
        option.WithOrigins(angularUrl);
        option.AllowAnyMethod();
        option.AllowAnyHeader();
    });
});

//Jwt Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(config =>
    {
        config.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration.GetSection("JwtSettings:Issuer").Value,
            ValidateAudience = true,
            ValidAudience = builder.Configuration.GetSection("JwtSettings:Audience").Value,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtSettings:SecretKey").Value??""))
        };
    });

builder.Services.AddDbContext<SalesRepDbContext>(option =>
{
    string connectionstring = builder.Configuration.GetConnectionString("Conn")??"";
    option.UseSqlServer(connectionstring);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AngularPolicy");
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
