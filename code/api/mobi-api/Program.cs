using FluentValidation.AspNetCore;
using mobi_api.Repository;
using mobi_api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using mobi_api.Services;
using mobi_api.DAO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMvc().AddFluentValidation(config =>
{
    config.RegisterValidatorsFromAssemblyContaining<Program>();
    config.ImplicitlyValidateChildProperties = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDevelopmentData, DevelopmentData>();
builder.Services.AddScoped<IStoreRepository, StoresRepository>();
builder.Services.AddScoped<IProductRepository, ProductsRepository>();
builder.Services.AddScoped<IUserRepository, UsersRepository>();
builder.Services.AddScoped<IGoogleAuthSupport, GoogleAuthSupport>();
builder.Services.AddScoped<IJwtService, JwtServices>();
builder.Services.AddSingleton<MobiConsumerContext>();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder
                 .AllowAnyOrigin()
                 .AllowAnyHeader()
                 .AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
