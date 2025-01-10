
using Filippov_Georgy_KT_31_21.TeacherService.DTOs;
using Filippov_Georgy_KT_31_21.TeacherService.DTOs.Mapper;
using Filippov_Georgy_KT_31_21.TeacherService.Entities;
using Filippov_Georgy_KT_31_21.TeacherService.UseCases;

using Microsoft.EntityFrameworkCore;

namespace Filippov_Georgy_KT_31_21.TeacherService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var str = builder.Configuration.GetConnectionString("Teachers");
        
        builder.Services.AddDbContextFactory<TeachersDbContext>(options => {
            options.UseNpgsql(builder.Configuration.GetConnectionString("Teachers"));
        });
        
        builder.Services.AddAutoMapper(typeof(Program).Assembly);

        builder.Services.AddScoped<GetTeachersByFilterQuery>();
        
        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
