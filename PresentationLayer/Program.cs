using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.Configuration;
using BusinessLayer.StrategyPattern;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.Controllers;
using FluentValidation;
using BusinessLayer.DTOs;
using BusinessLayer.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<LotDBContext>(options =>
                options.UseInMemoryDatabase(databaseName: "MockStockDb"));
builder.Services.AddTransient<IRepository<Lot>, LotRepository>();

builder.Services.AddTransient<ISharesSaleCalculationStrategy, FIFOStrategy>(); //default strategy
builder.Services.AddTransient<ILotService, LotService>();
builder.Services.AddTransient<IValidator<SaleSharesDTO>, SaleSharesValidator>();

builder.Services.AddTransient<LotController>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
