using Microsoft.EntityFrameworkCore;
using WEBSITES.Data;
using Microsoft.AspNetCore.Identity;
using WEBSITES.Models;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DBCONTEXT>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRazorPages();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<DBCONTEXT>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

builder.Services.AddScoped<IEmailSender, EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Enforce HTTPS and security headers
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Custom routes for CategoryController
app.MapControllerRoute(
    name: "category_create",
    pattern: "category/Add",
    defaults: new { controller = "Category", action = "Create" }
);

app.MapControllerRoute(
    name: "category_edit",
    pattern: "category/Update/{id}",
    defaults: new { controller = "Category", action = "Edit" }
);

//app.MapControllerRoute(
//    name: "category_delete",
//    pattern: "category/Remove/{id}",
//    defaults: new { controller = "Category", action = "Delete" }
//);

app.MapControllerRoute(
    name: "category_index",
    pattern: "category/index",
    defaults: new { controller = "Category", action = "Index" }
);

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapRazorPages();

app.Run();