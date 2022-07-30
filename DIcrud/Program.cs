using Microsoft.EntityFrameworkCore;
using DIcrud.Models;
using DIcrud.CustomExc;
using DIcrud.Repo;
using DIcrud.Controllers;
using DIcrud;
using Microsoft.AspNetCore.Identity;
using DIcrud.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UserContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//
builder.Services.ConfigureServices();
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new AppRole());

});
//builder.Services.AddScoped<AppRoleAttribute>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
   
}
app.ConfigureCustomExceptionMiddleware();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
