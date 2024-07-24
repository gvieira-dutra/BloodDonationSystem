using BloodDonationSystem.Application.Interfaces;
using BloodDonationSystem.Application.Services.Implementation;
using BloodDonationSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("BlookBankSystemCs");

builder.Services.AddDbContext<BloodDonationDbContext>(s => s.UseSqlServer(connectionString));

builder.Services.AddScoped<IBloodStock, BloodStockService>();
builder.Services.AddScoped<IDonation, DonationService>();
builder.Services.AddScoped<IDonor, DonorService>();

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
