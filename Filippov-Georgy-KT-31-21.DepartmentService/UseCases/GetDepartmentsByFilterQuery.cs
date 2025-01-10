using AutoMapper;

using Filippov_Georgy_KT_31_21.DepartmentService.DTOs;

using Microsoft.EntityFrameworkCore;

namespace Filippov_Georgy_KT_31_21.DepartmentService.UseCases;

public class GetDepartmentsByFilterQuery {
    private readonly IDbContextFactory<DepartmentsDbContext> _dbContextFactory;
    private readonly IMapper _mapper;

    public GetDepartmentsByFilterQuery(IDbContextFactory<DepartmentsDbContext> dbContextFactory, IMapper mapper) {
        _dbContextFactory = dbContextFactory;
        _mapper = mapper;
    }

    public async Task<DepartmentCrudDto[]> ExecuteAsync(GetDepartmentsFilterDto filterDto, CancellationToken cancellationToken = default) {
        await using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        var query = context.Departments.AsNoTracking();
        if (filterDto.FoundationDateStart is not null) {
            query = query.Where(d => d.FoundationDate >= filterDto.FoundationDateStart);
        }
        if (filterDto.FoundationDateEnd is not null) {
            query = query.Where(d => d.FoundationDate <= filterDto.FoundationDateEnd);
        }
        if (filterDto.TeachersCountStart is not null) {
            throw new NotImplementedException();
        }
        if (filterDto.TeachersCountEnd is not null) {
            throw new NotImplementedException(); 
        }

        return await query
            .Select(d => _mapper.Map<DepartmentCrudDto>(d))
            .ToArrayAsync(cancellationToken);
    }
}