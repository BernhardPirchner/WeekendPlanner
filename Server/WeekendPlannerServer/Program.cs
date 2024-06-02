using WeekendPlannerServer.Models;
using WeekendPlannerServer.Services;
using WeekendPlannerServer.Controller;

namespace WeekendPlannerServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<DatabaseSettings>(
                builder.Configuration.GetSection("WeekendPlanner"));

            builder.Services.AddSingleton<UserService>();
            builder.Services.AddSingleton<FestivalService>();
            

            

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
