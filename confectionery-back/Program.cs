using AutoMapper;
using confectionery_back.DataContext;
using confectionery_back.DTO;
using confectionery_back.Model;
using confectionery_back.Service.UserServices;
using confectionery_back.ViewModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<UserDto, User>();
    cfg.CreateMap<User, UserViewModel>();
});

IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDbContext<ConfectionaryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConfectionaryContext"));
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
