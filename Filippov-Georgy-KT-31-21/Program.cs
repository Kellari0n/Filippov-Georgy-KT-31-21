using Filippov_Georgy_KT_31_21.Context;
using Filippov_Georgy_KT_31_21.Middlewares;
using Filippov_Georgy_KT_31_21.ServiceExtentions;

using Microsoft.EntityFrameworkCore;

using NLog;
using NLog.Web;

internal class Program {
    private static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);
        var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

        try {
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddStudyServices();

            builder.Services.AddDbContextFactory<StudyDbContext>(options => { 
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")); 
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.MapControllers();

            app.Run();
        }
        catch (Exception ex) {
            logger.Error(ex, "Stopped program because of exception");
        }
        finally {
            LogManager.Shutdown();
        }
    }
}