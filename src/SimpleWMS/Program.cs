using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SimpleWMS.Data;
using SimpleWMS.Database.Context;
using SimpleWMS.Mdels;
using SimpleWMS.Mdels.Repository;
using SimpleWMS.Models.Services;
using SimpleWMS.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<WarehouseRepository>();
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<WareHouseManagementService>();
builder.Services.AddScoped<StockHistoryViewModel>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
