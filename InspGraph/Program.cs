using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using InspGraph.ViewModels;
using InspGraph;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using InspGraph.Data;
using InspGraph.Operator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<StatisticsViewModel>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

#if DEBUG
Select.EnsureDeleted();
#endif
if (Select.EnsureCreated())
{
    DbInitializer.Initialize();
}
app.Run();
