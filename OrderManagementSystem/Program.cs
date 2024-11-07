using MassTransit;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Consumers;
using OrderManagementSystem.Data;
using OrderManagementSystem.Data.Repositories;
using OrderManagementSystem.Middleware;
using OrderManagementSystem.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var sc = builder.Services;
Log.Logger = new LoggerConfiguration().CreateLogger();

sc.AddControllers();
sc.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

sc.AddEndpointsApiExplorer();
sc.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        var rabbitMqOptions = builder.Configuration.GetSection("RabbitMQ");

        cfg.Host(rabbitMqOptions["Host"], h =>
        {
            h.Username(rabbitMqOptions["Username"]!);
            h.Password(rabbitMqOptions["Password"]!);
        });
    });

    x.AddConsumer<OrderConsumer>();
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<MassTransitService>();
builder.Services.AddScoped<TokenService>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.Run();