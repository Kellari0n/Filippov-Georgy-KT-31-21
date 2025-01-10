using System.Text.Json;

using AutoMapper;

using Filippov_Georgy_KT_31_21.DepartmentService.DTOs;
using Filippov_Georgy_KT_31_21.TeacherService.DTOs;

using Microsoft.EntityFrameworkCore;

namespace Filippov_Georgy_KT_31_21.DepartmentService.UseCases;

public class GetDepartmentsByFilterQuery {
    private readonly IDbContextFactory<DepartmentsDbContext> _dbContextFactory;
    private readonly IMapper _mapper;
    private IHttpClientFactory _httpClientFactory;

    public GetDepartmentsByFilterQuery(IDbContextFactory<DepartmentsDbContext> dbContextFactory, IMapper mapper, IHttpClientFactory httpClientFactory) {
        _dbContextFactory = dbContextFactory;
        _mapper = mapper;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<DepartmentCrudDto[]> ExecuteAsync(GetDepartmentsFilterDto filterDto, CancellationToken cancellationToken = default) {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        var query = context.Departments.AsNoTracking();
        IEnumerable<DepartmentCrudDto> result = [];
        if (filterDto.FoundationDateStart.HasValue) {
            query = query.Where(d => d.FoundationDate >= filterDto.FoundationDateStart);
        }
        if (filterDto.FoundationDateEnd.HasValue) {
            query = query.Where(d => d.FoundationDate <= filterDto.FoundationDateEnd);
        }
        if (filterDto.TeachersCountStart.HasValue || filterDto.TeachersCountEnd.HasValue) {
            using var client = _httpClientFactory.CreateClient("teacher_service");
            var teachersResp = await client.GetAsync("api/teachers");
            if (teachersResp.IsSuccessStatusCode) {
                var content = await teachersResp.Content.ReadAsStringAsync();
                var teachers = JsonSerializer.Deserialize<List<TeacherDto>>(content, new JsonSerializerOptions {
                    PropertyNameCaseInsensitive = true
                });
                var departmentsTeacherCount = teachers.GroupBy(t => t.DepartmentId)
                    .Select(g => new { DepartmentId = g.Key, teachersCount = g.Count() });

                var departments = query.AsEnumerable();
                
                if (filterDto.TeachersCountStart.HasValue) {
                    departments = departments.Where(d => departmentsTeacherCount.First(dtc => dtc.DepartmentId == d.Id).teachersCount >= filterDto.TeachersCountStart);
                }
                if (filterDto.TeachersCountEnd.HasValue) {
                    departments = departments.Where(d => departmentsTeacherCount.First(dtc => dtc.DepartmentId == d.Id).teachersCount <= filterDto.TeachersCountEnd);
                }
                result = departments.Select(d => _mapper.Map<DepartmentCrudDto>(d)).ToArray();
            }
            else {
                throw new HttpRequestException() {
                    HResult = (int)teachersResp.StatusCode,
                    
                };
            }
        }

        return result.ToArray();
    }
}