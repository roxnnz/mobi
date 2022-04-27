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
builder.Services.AddScoped<IStoreRepository, StoresRepository>();
builder.Services.AddScoped<IProductRepository, ProductsRepository>();
builder.Services.AddScoped<IUserRepository, UsersRepository>();

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

// TODO: For testing purpose, move to correct places:
using (var db = new MobiConsumerContext())
{
    Console.WriteLine($"Database path: {db.DbPath}.");

    var newStore = new StoreEntity();
    newStore.StoreName = "Jimmy Noodle";
    newStore.PhoneNumber = "201923033";
    newStore.WebSite = "www.checkout.com";

    db.Add(newStore);
    db.SaveChanges();

    var store = db.Stores
                  .OrderBy(s => s.StoreId)
                  .First();
    Console.WriteLine(store);


    var newProduct = new ProductEntity();
    newProduct.Description = "First Prod";
    newProduct.Price = 12;
    newProduct.StoreId = 2;
    
    db.Add(newProduct);
    db.SaveChanges();

    var product = db.Products
               .OrderBy(b => b.ProductId)
               .First();

   
    Console.WriteLine(product);
}

app.UseAuthorization();

app.MapControllers();

app.Run();
