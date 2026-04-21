using AutoMapper;
using DotNetEnv;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Mapping;
using papaMiaBackend.DataAccess;
using papaMiaBackend.DataAccess.Context;
using papaMiaBackend.Domain.Entities.User;
using papaMiaBackend.Domain.Models.Auth;

var envPath = Path.Combine(AppContext.BaseDirectory, ".env");
if (File.Exists(envPath))
{
    Env.Load(envPath);
} else {
    throw new InvalidOperationException("Set .env file");
}

var builder = WebApplication.CreateBuilder(args);

DbSession.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<UserContext>(options => options.UseNpgsql(DbSession.ConnectionString));
builder.Services.AddDbContext<ProductContext>(options => options.UseNpgsql(DbSession.ConnectionString));
builder.Services.AddDbContext<LocationContext>(options => options.UseNpgsql(DbSession.ConnectionString));
builder.Services.AddDbContext<BannerContext>(options => options.UseNpgsql(DbSession.ConnectionString));
builder.Services.AddDbContext<CartContext>(options => options.UseNpgsql(DbSession.ConnectionString));

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

builder.Services.Configure<JwtGenerationSettings>(builder.Configuration.GetSection(JwtGenerationSettings.SectionName));
var jwt = builder.Configuration.GetSection(JwtGenerationSettings.SectionName).Get<JwtGenerationSettings>();
if (jwt is null)
    throw new InvalidOperationException("Set JWT in project");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<UserMappingProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<ProductMappingProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<CartMappingProfile>());
builder.Services.AddScoped<BusinessLogicManager>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseForwardedHeaders();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
