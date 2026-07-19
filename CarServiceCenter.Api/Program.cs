using CarServiceCenter.Application.Services;
using CarServiceCenter.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<VehicleService>();
builder.Services.AddScoped<TechnitianService>();
builder.Services.AddScoped<ServiceTypeService>();
builder.Services.AddScoped<ServiceTypeItemService>();
builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<BookingServiceItemService>();
builder.Services.AddScoped<ApprovalRequestService>();

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
