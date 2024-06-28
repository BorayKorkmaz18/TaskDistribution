using Microsoft.EntityFrameworkCore;
using System;
using TaskDistribution.BusinessLayer.Abstract;
using TaskDistribution.BusinessLayer.Concrete;
using TaskDistribution.DataAcessLayer.Abstract;
using TaskDistribution.DataAcessLayer.Concrete;
using TaskDistribution.DataAcessLayer.EntityFramework;
using TaskDistribution.DataAcessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<TaskDistributionContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

builder.Services.AddScoped<IEmployeeService, EmployeeManager>();
builder.Services.AddScoped<IEmployeeDal, EfEmployeeDal>();
builder.Services.AddScoped<IRoleService, RoleManager>();
builder.Services.AddScoped<IRoleDal, EfRoleDal>();
builder.Services.AddScoped<IIssueService, IssueManager>();
builder.Services.AddScoped<IIssueDal, EfIssueDal>();
builder.Services.AddScoped<ITaskProcessingService, TaskProcessingManager>();
builder.Services.AddScoped<ITaskProcessingDal, EfTaskProcessingDal>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});


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
