using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;
using System.Text;
using WMS.Data;
using WMS.Models;
using System.Collections.Generic;  

// The following declaration generates CS0246.  

// To avoid the error, fully qualify List.  
using myAliasName2 = System.Collections.Generic.List<int>;
using WMS.Repository;
using WMS.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        //
        builder.Services.AddDataProtection()
          .SetApplicationName("WMS");
        // Add services to the container.
        builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("defualtConnection")));

        builder.Services.AddIdentity<Users, Roles>(option =>
        {
            option.Password.RequireUppercase = false; option.Password.RequiredLength = 6;
            option.Password.RequireDigit = false; option.Password.RequireNonAlphanumeric = false;
            option.Password.RequireUppercase = false; option.Password.RequireLowercase = false;
            //قفل حساب المستخدم لمدة 1دقائق اذا حاول تسجيل الدخول اكثر من خمس مرات خاطئة
            option.Lockout.AllowedForNewUsers = true;
            option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
            option.Lockout.MaxFailedAccessAttempts = 5;


        }).AddEntityFrameworkStores<AppDbContext>();

        //builder.Services.AddCors();

        //اضافة خدمة حماية البيانات من اجل تشفير بيانات الجلسة وغيرها
        builder.Services.AddDataProtection();
        //

        builder.Services.AddControllersWithViews()
            .AddSessionStateTempDataProvider();
        builder.Services.AddDistributedMemoryCache();
        //تحديد تكوين الجلسة
        builder.Services.AddSession(options =>
        {
            //options.Cookie.Name = ".AdventureWorks.Session";
            options.IdleTimeout = TimeSpan.FromMinutes(30);

            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;

        });
        //يتم استخدامه لتعيين الفاصل الزمني للتحقق من صحة طوابع أمان هوية ASP.NET.
        /// <summary>
        /// إذا مرت أكثر من دقيقة واحدة دون طلب
        /// يوفر هذا فاصلًا زمنيًا صارمًا للتحقق من الصحة للكشف الفوري عن أي تغييرات تطرأ على حساب المستخدم.
        /// </summary>
        builder.Services.Configure<SecurityStampValidatorOptions>(options =>
        {
            options.ValidationInterval = TimeSpan.FromMinutes(30);
        });

        builder.Services.AddScoped<IInvSysRepository<ItemGroup>, ItemGroupMainRepository>();
        // تكوين سياسات الوصول
        builder.Services.AddAuthorization(options =>
        {
            // تحديد سياسات التحكم في الوصول
            options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            options.AddPolicy("User", policy => policy.RequireRole("User"));
            options.AddPolicy("SuperAdmin", policy => policy.RequireRole("SuperAdmin"));


        });
        //


        //

        builder.Services.AddMvc(options =>
        {
            options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                (_) => "The field is required.");
        }).AddSessionStateTempDataProvider();

        /*builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
                // options.SlidingExpiration = true;//تجديد الجلسة مادام المستخدم يتفاعل مع التطبيق
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.Redirect("/Account/Login");
                    return Task.CompletedTask;
                };
                options.Events.OnRedirectToAccessDenied = context =>
                {
                    context.Response.Redirect("/Account/AccessDenied");
                    return Task.CompletedTask;
                };

            });
        */


        builder.Services.AddScoped<MainRepository<BaseModel>>();
        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddScoped<SignInManager<Users>>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }


        // add session middleware
        app.UseSession();
        //
        app.Use(async (context, next) =>
        {
            await next.Invoke();
            // Check session timeout here
            if (context.Session.IsAvailable)
            {
                // Session has not expired, so skip

                return;
            }
            /*    // Session has expired, redirect to login page
                var loginPath = "/Account/Login"; // Replace with your login page path
                context.Response.Redirect(loginPath);*/
            // Redirect to logout page
            context.Response.Redirect("/Logout");


            // Redirect to logout page
            context.Response.Redirect("/Logout");
            //...
        });

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();



        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=AccountLogin}/{action=Login}");

        app.Run();
    }
}