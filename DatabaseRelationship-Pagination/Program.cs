using AutoMapper;
using BLL;
using BLL.Repository.Implementation;
using BLL.Repository.Interface;
using DAL;
using DAL.DbContext;
using DatabaseRelationship_Pagination.Configs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DatabaseRelationship_Pagination.Areas.Identity.Data;
using DAL.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PaginationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'PaginationDbContextConnection' not found.");

builder.Services.AddDbContext<PaginationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<PaginationDbContext>();





ConfigurationManager configuration = builder.Configuration;
builder.Services
    .AddBLL()
    .AddDAL(configuration);


//builder.Services.AddIdentity<DatabaseRelationship_PaginationContext, IdentityRole>()
//    .AddEntityFrameworkStores<DatabaseRelationship_PaginationContext>()
//    .AddDefaultUI()
//    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();

//AutoMapperConfiguration
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);




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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Scaffolding is actually used for Razer pages, but we add this in MVC project
app.MapRazorPages();

app.Run();



    
  
