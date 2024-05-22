using WeekendPlanner_API.Models;
using WeekendPlanner_API.Services;

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

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
