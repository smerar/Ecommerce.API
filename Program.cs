using AutoMapper;
using Ecommerce.API.Data;
using Ecommerce.API.Helper;
using Ecommerce.API.Services.ServiceClasses;
using Ecommerce.API.Services.ServiceInterfaces;
using Ecommerce.Services.Service_Classes;
using Ecommerce.Services.Service_Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("EcommerceApiDbConnectionString");

// Add services to the container.
builder.Services.AddDbContext<EcommerceApiDbContext>(options => {
    options.UseSqlServer(connectionString);
    }
);
builder.Services.AddControllers();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICartService, CartService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ECommerce API",
        Description = "An ASP.NET Core Web API for managing Ecommerce Web Application",
       
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddAutoMapper(typeof(MapperConfig));
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
