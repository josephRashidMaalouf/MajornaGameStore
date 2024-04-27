using MajornaGameStore.Api.Extensions;
using MajornaGameStore.Api.Stripe;
using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Mongo;
using MajornaGameStore.DataAccess.Services;
using MajornaGameStore.DataAccess;
using MajornaGameStore.DataAccess.Sql;
using MajornaGameStore.DataAccess.Sql.Repositories;
using MajornaGameStore.Shared.Interfaces.RepositoryInterfaces;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System;
using MajornaGameStore.Shared;
using DiscountService = MajornaGameStore.DataAccess.Services.DiscountService;
using EventService = MajornaGameStore.DataAccess.Services.EventService;
using ProductService = MajornaGameStore.DataAccess.Services.ProductService;
using ReviewService = MajornaGameStore.DataAccess.Services.ReviewService;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("majornaDbLocal");

builder.Services.AddDbContext<MajornaDbContext>(
    options =>
        options.UseSqlServer(connectionString));

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
builder.Services.AddAuthorizationBuilder();

builder.Services.AddIdentityCore<User>()
    .AddRoles<Role>()
    .AddEntityFrameworkStores<MajornaDbContext>()
    .AddApiEndpoints();

builder.Services
    .AddScoped<IProductRepository, ProductRepository>()
    .AddScoped<ITypeRepository, TypeRepository>()
    .AddScoped<IDeveloperRepository, DeveloperRepository>()
    .AddScoped<IPublisherRepository, PublisherRepository>()
    .AddScoped<IScreenshotRepository, ScreenshotRepository>()
    .AddScoped<ITagRepository, TagRepository>()
    .AddScoped<IDiscountRepository, DiscountRepository>()
    .AddScoped<IEventRepository, EventRepository>()
    .AddScoped<IEventTypeRepository, EventTypeRepository>()
    .AddScoped<IReviewRepository, ReviewRepository>()
    .AddScoped<IEventTypeRepository, EventTypeRepository>()
    .AddScoped<IOrderRepository, OrderRepository>()
    .AddScoped<IUserRepository, UserRepository>();

builder.Services
    .AddScoped<ProductService>()
    .AddScoped<DiscountService>()
    .AddScoped<TagService>()
    .AddScoped<ProductTypeService>()
    .AddScoped<EventService>()
    .AddScoped<ProductTypeService>()
    .AddScoped<DeveloperService>()
    .AddScoped<PublisherService>()
    .AddScoped<ScreenshotService>()
    .AddScoped<TagService>()
    .AddScoped<ReviewService>()
    .AddScoped<EventTypeService>()
    .AddScoped<UserService>()
.AddScoped<OrderService>();

builder.Services.AddOptions<StripeConfig>().BindConfiguration(nameof(StripeConfig));

builder.Services.AddScoped<MajornaGameStore.Api.Stripe.StripeClient>();





builder.Services.AddCors(
    options => options.AddPolicy(
        name: "MyAllowSpecificOrigins",
        policy => policy.WithOrigins("https://localhost:7207", "https://majornaggapi.azurewebsites.net", "https://majornagamestore.azurewebsites.net")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()));


builder.Services.AddRouting(options => options.LowercaseUrls = true);
//builder.Services.AddControllers();


var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();

    await using var scope = app.Services.CreateAsyncScope();
    await SeedUserData.InitializeAsync(scope.ServiceProvider);
}



app.MapIdentityApi<User>();
app.UseCors("MyAllowSpecificOrigins");
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

//app.MapLoadProductEndPoints();
app.MapProductEndPoints();
app.MapEventEndPoints();
app.MapEventTypeEndPoints();
app.MapOrderEndPoints();
app.MapPaymentsEndPoints();
app.MapUserEndPoints();
app.MapDiscountEndPoints();
app.MapProductTypeEndpoints();
app.MapDeveloperEndPoints();
app.MapPublisherEndPoints();
app.MapProductTagEndpoints();
//app.MapControllers();

app.Run();
