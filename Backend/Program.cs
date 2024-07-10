using Backend.Controllers;
using Backend.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(GlobalConfiguration.ConfigureSwaggerGenOptions());

builder.Services.AddDbContext<ProductivAPIDbContext>(options =>
{
    options.UseSqlite("Data Source=productiv.db");
});
builder.Services.AddScoped<IGoalRepository, GoalRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
