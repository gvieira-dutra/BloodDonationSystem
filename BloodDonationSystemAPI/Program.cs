using BloodDonationSystem.Application.Command.DonorCreate;
using BloodDonationSystem.Application.Validators;
using BloodDonationSystem.Core.Repository;
using BloodDonationSystem.Infrastructure.Persistence;
using BloodDonationSystem.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using BloodDonationSystemAPI.Filters;
using FastReport.Data;
using BloodDonationSystem.Infrastructure.MailService.Configurations;
using BloodDonationSystem.Infrastructure.Configurations.Service;
using BloodDonationSystem.Infrastructure.MailService.Service;
using BloodDonationSystem.Infrastructure.PostalCodeService.PostalCodeSettings;
using BloodDonationSystem.Infrastructure.PostalCodeService.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(option => option.Filters.Add(typeof(ValidationFilter)));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("BlookBankSystemCs");

builder.Services.AddFastReport();
builder.Services.AddDbContext<BloodDonationDbContext>(s => s.UseSqlServer(connectionString));
builder.Services.AddScoped<IBloodStockRepository, BloodStockRepository>();
builder.Services.AddScoped<IDonationRepository, DonationRepository>();
builder.Services.AddScoped<IDonorRepository, DonorRepository>();

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.Configure<PostalCodeSetUp>(builder.Configuration.GetSection("PostalCodeSetting"));

FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));

builder.Services.AddMediatR(typeof(DonorCreateCommand));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<DonationPutCommandValidator>();

builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddScoped<IPostalCodeService, PostalCodeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.UseFastReport();

app.MapControllers();

app.Run();
