using FastDeliveriApi.Data;
using FastDeliveriApi.Middleware;
using FastDeliveriApi.Repositories;
using FastDeliveriApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.Decorate<ICustomerRepository, CachedCustomerRepository>();

builder.Services.AddMemoryCache();

var connectinString = builder.Configuration.GetConnectionString("MyDbPgsql");
builder.Services.AddDbContext<FastDeliveriDbContext>(options => {
    options.UseNpgsql(connectinString);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
    b => b.AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExeptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

