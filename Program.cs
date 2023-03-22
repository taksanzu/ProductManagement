using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Models.Products;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProductContext>(optionsAction =>
    optionsAction.UseSqlServer("name=ConnectionStrings:LocalDb")
    );
builder.Services.AddScoped<iProductRepository, ProductRepository>();
// Using Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ProductContext>();
//Using for cart
builder.Services.AddMemoryCache();
builder.Services.AddSession();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();
app.UseAuthentication(); // Using with Identity

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shopping}/{action=List}/{id?}");

app.Run();
