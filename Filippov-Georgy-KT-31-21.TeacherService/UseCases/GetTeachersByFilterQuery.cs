using AutoMapper;

using Filippov_Georgy_KT_31_21.TeacherService.DTOs;
using Filippov_Georgy_KT_31_21.TeacherService.Entities;

using Microsoft.EntityFrameworkCore;

namespace Filippov_Georgy_KT_31_21.TeacherService.UseCases;

public class GetTeachersByFilterQuery {
    private readonly IDbContextFactory<TeachersDbContext> _dbContextFactory;
    private readonly IMapper _mapper;
    
    public GetTeachersByFilterQuery(IDbContextFactory<TeachersDbContext> dbContextFactory, IMapper mapper) {
        _dbContextFactory = dbContextFactory;
        _mapper = mapper;
    }
    
    public async Task<TeacherDto[]> ExecuteAsync(GetTeachersFilterDto filter) {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var query = context.Teachers.AsNoTracking();

        if (filter.DepartmentId.HasValue) {
            query = query.Where(t => t.DepartmentId == filter.DepartmentId);
        }
        if (filter.DegreeId.HasValue) {
            query = query.Where(t => t.DegreeId == filter.DegreeId);
        }
        if (filter.PostId.HasValue) {
            query = query.Where(t => t.PostId == filter.PostId);
        }
        
        return await query.Select(t => _mapper.Map<TeacherDto>(t)).ToArrayAsync();
    }
}