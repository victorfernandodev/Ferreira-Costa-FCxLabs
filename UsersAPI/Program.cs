using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using UsersAPI.Context;
using UsersAPI.Repositories;
using UsersAPI.Repositories.Interface;
using UsersAPI.Services;
using UsersAPI.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
                   options.UseMySql(mySqlConnection,
                   ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddControllers()
      .AddJsonOptions(options =>
        options.JsonSerializerOptions
         .ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

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