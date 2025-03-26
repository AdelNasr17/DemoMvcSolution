using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.DepartmentService;
using Demo.BusinessLogic.Services.EmployeeService;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Repositories.Employees;
using Demo.DataAccess.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace Route.Demo.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region Add services to the container
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped<ApplicationDbContext>(); //2. Rigister To Service In DI Container
            builder.Services.AddDbContext<ApplicationDbContext>( options=>
                {
                   
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

                });
            //builder.Services.AddScoped<DepartmentRepository>();
            //builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();





            #endregion

            var app = builder.Build();

            #region Configure the HTTP request pipeline.
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            #endregion
            app.Run();
        }
    }
}
