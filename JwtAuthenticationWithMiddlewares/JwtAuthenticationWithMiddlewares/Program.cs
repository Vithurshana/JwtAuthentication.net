using Microsoft.EntityFrameworkCore;
using JwtAuthenticationWithMiddlewares;
using JwtAuthenticationWithMiddlewares.Helpers.Utils;
using JwtAuthenticationWithMiddlewares.Services.UserService;
using JwtAuthenticationWithMiddlewares.Services.StoryService;
using JwtAuthenticationWithMiddlewares.Services.AuthenticateService;
using JwtAuthenticationWithMiddlewares.Services.ListUsersService;
using JwtAuthenticationWithMiddlewares.Middlewares;

var builder = WebApplication.CreateBuilder(args);

GlobalAttributes.mysqlConfiguration.connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStoryService, StoryService>();
builder.Services.AddScoped<IAutheticateService, AuthenticateService>();
builder.Services.AddScoped<IListUsersService, ListUsersService>();


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

app.UseMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
