using AutoMapper;
using confectionery_back.DataContext;
using confectionery_back.DTO;
using confectionery_back.Model;
using confectionery_back.Service.BiscuitServices;
using confectionery_back.Service.CookieServices;
using confectionery_back.Service.FillingServices;
using confectionery_back.Service.OrderServices;
using confectionery_back.Service.UserServices;
using confectionery_back.ViewModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<UserDto, User>();
    cfg.CreateMap<User, UserViewModel>();

    cfg.CreateMap<BiscuitDto, Biscuit>();
    cfg.CreateMap<Biscuit, BiscuitViewModel>();

    cfg.CreateMap<FillingDto, Filling>();
    cfg.CreateMap<Filling, FillingViewModel>();

    cfg.CreateMap<CookieDto, Cookie>();
    cfg.CreateMap<Cookie, CookieViewModel>();

    cfg.CreateMap<OrderDto, Order>();
    cfg.CreateMap<Order, OrderViewModel>();
});

IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBiscuitService, BiscuitService>();
builder.Services.AddScoped<IFillingService, FillingService>();
builder.Services.AddScoped<ICookieService, CookieService>();
builder.Services.AddScoped<IOrderService, OrderService>();

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
