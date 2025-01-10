using Filippov_Georgy_KT_31_21.DepartmentService.DTOs;
using Filippov_Georgy_KT_31_21.DepartmentService.Entity;
using Filippov_Georgy_KT_31_21.DepartmentService.UseCases;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Filippov_Georgy_KT_31_21.DepartmentService;

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

        builder.Services.AddDbContextFactory<DepartmentsDbContext>(options => {
            options.UseSqlite(builder.Configuration.GetConnectionString("Departments"));
        });
        
        builder.Services.AddAutoMapper(cfg => {
            cfg.CreateMap<Department, DepartmentCrudDto>();
        });

        builder.Services.AddScoped<GetDepartmentsByFilterQuery>();
        
        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapGet("/", () => "Test");
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}