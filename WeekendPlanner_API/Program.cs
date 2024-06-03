using WeekendPlanner_API.Models;
using WeekendPlanner_API.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;

namespace WeekendPlanner_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<UserDatabaseSettings>(
                builder.Configuration.GetSection("UserDatabase"));
            builder.Services.AddSingleton<UserService>();

            builder.Services.Configure<EventDatabaseSettings>(
                builder.Configuration.GetSection("EventDatabase"));
            builder.Services.AddSingleton<EventService>();

            builder.Services.Configure<ProtoEventDatabaseSettings>(
                builder.Configuration.GetSection("ProtoEventDatabase"));
            builder.Services.AddSingleton<ProtoEventService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = ".MyApp.Session";
                options.IdleTimeout=TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.SameSite=SameSiteMode.None;
                options.Cookie.SecurePolicy=CookieSecurePolicy.Always;
            });

            builder.Services.AddHealthChecks();
            
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("https://localhost:7002", "http://localhost:5173")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseSession();
            app.MapHealthChecks("/health");
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseRouting();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
