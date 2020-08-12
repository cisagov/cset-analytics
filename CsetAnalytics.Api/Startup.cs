using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CsetAnalytics.Business;
using CsetAnalytics.Business.Analytics;
using CsetAnalytics.Business.Dashboard;
using CsetAnalytics.DomainModels;
using CsetAnalytics.DomainModels.Models;
using CsetAnalytics.Factories;
using CsetAnalytics.Factories.Analytics;
using CsetAnalytics.Interfaces;
using CsetAnalytics.Interfaces.Analytics;
using CsetAnalytics.Interfaces.Dashboard;
using CsetAnalytics.Interfaces.Factories;
using CsetAnalytics.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace CsetAnalytics.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment HostingEnvironment { get; set; }
        private IConfigurationRoot _config;

        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", optional: true,
                    reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = configuration;
            this.HostingEnvironment = hostingEnvironment;
            _config = builder.Build();
        }

        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });
            services.AddControllers();
            services.AddSingleton(_config);

            services.AddAutoMapper(typeof(FactoryProfile));

            services.Configure<MongoDbSettings>(Configuration.GetSection(nameof(MongoDbSettings)));
            services.AddSingleton<MongoDbSettings>(sp => sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            //var pgUser = "inl_user"; // Environment.GetEnvironmentVariable("POSTGRES_USER");
            //var pgPwd = "1qaz!QAZ"; // Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
            //var pgDb = "CsetAnalytics"; //Environment.GetEnvironmentVariable("POSTGRES_DB");
            //var pgPort = "5432"; // Environment.GetEnvironmentVariable("POSTGRES_PORT");
            //ar pgHost = "localhost"; //Environment.GetEnvironmentVariable("POSTGRES_SERVER");
           //var connectionString = String.Format(
           //    "Server={0};Port={1};Database={2};UserId={3};Password={4}",
           //    pgHost, pgPort, pgDb, pgUser, pgPwd
           // );

            //services.AddDbContext<CsetContext>(options =>
            //    options.UseNpgsql(connectionString, b=>b.MigrationsAssembly("CsetAnalytics.DomainModels")));
            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<CsetContext>()
            //    .AddDefaultTokenProviders();
            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequireDigit = true;
            //    options.Password.RequiredLength = 8;
            //    options.Password.RequireNonAlphanumeric = true;
            //    options.Password.RequireUppercase = true;
            //    options.Password.RequireLowercase = true;

            //    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(Int32.Parse(Configuration["Login:DefaultLockoutTimespan"]));
            //    options.Lockout.AllowedForNewUsers = true;

            //    options.User.RequireUniqueEmail = true;
            //});

            //var key = Encoding.ASCII.GetBytes(Configuration["Tokens:Key"]);
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(o =>
            //{
            //    o.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidateIssuerSigningKey = true, 
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false, 
            //        ValidateAudience = false
                    
            //    };
            //});

            //Business
            services.AddTransient<IUserBusiness, UsersBusiness>();
            services.AddTransient<IAnalyticBusiness, AnalyticsBusiness>();
            services.AddTransient<IDashboardBusiness, DashboardBusiness>();

            //Factories
            services.AddTransient<IBaseFactory<AnalyticQuestionViewModel, AnalyticQuestionAnswer>, AnalyticQuestionModelFactory>();
            services.AddTransient<IBaseFactory<AnalyticQuestionAnswer, AnalyticQuestionViewModel>, AnalyticQuestionViewModelFactory>();
            services.AddTransient<IBaseFactory<AnalyticAssessmentViewModel, Assessment>, AnalyticAssessmentFactory>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CsetContext>();
                //context.Database.Migrate();
            }

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("X-Xss-Protection", "1");
                await next();
            });

            app.UseAuthentication();

            //IdentityDataInitializer.SeedRoles().GetAwaiter();

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
