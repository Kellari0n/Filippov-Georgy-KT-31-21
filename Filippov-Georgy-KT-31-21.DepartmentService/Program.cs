using Filippov_Georgy_KT_31_21.DepartmentService.DTOs;
using Filippov_Georgy_KT_31_21.DepartmentService.Entity;
using Filippov_Georgy_KT_31_21.DepartmentService.UseCases;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Filippov_Georgy_KT_31_21.DepartmentService;

public class Program {
    public static void Main(string[] args) {
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
            cfg.CreateMap<DepartmentCrudDto, Department>();
        });

        builder.Services.AddHttpClient("teacher_service", x=> x.BaseAddress = new Uri(Environment.GetEnvironmentVariable("services__teacherservice__https__0") ?? throw new InvalidOperationException()));
        
        builder.Services.AddScoped<GetDepartmentsByFilterQuery>();

        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment()) {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}