using WebApiProducts_MongoDB.Models;
using WebApiProducts_MongoDB.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ProductsDatabaseSettings>(
    builder.Configuration.GetSection("ProductsSettings"));
// Add services to the container.
builder.Services.AddSingleton<ProductService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
