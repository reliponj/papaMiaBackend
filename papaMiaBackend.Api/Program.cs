using AutoMapper;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using papaMiaBackend.BusinessLogic;
using papaMiaBackend.BusinessLogic.Mapping;
using papaMiaBackend.DataAccess;
using papaMiaBackend.DataAccess.Context;

var envPath = Path.Combine(AppContext.BaseDirectory, ".env");
if (File.Exists(envPath))
{
    Env.Load(envPath);
}

var builder = WebApplication.CreateBuilder(args);

DbSession.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<UserContext>(options => options.UseNpgsql(DbSession.ConnectionString));
builder.Services.AddDbContext<ProductContext>(options => options.UseNpgsql(DbSession.ConnectionString));
builder.Services.AddDbContext<LocationContext>(options => options.UseNpgsql(DbSession.ConnectionString));
builder.Services.AddDbContext<BannerContext>(options => options.UseNpgsql(DbSession.ConnectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<UserMappingProfile>());
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<ProductMappingProfile>());
builder.Services.AddScoped<BusinessLogicManager>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
