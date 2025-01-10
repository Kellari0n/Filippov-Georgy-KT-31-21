using AutoMapper;

using Filippov_Georgy_KT_31_21.DepartmentService.DTOs;
using Filippov_Georgy_KT_31_21.DepartmentService.Entity;

using Microsoft.EntityFrameworkCore;

namespace Filippov_Georgy_KT_31_21.DepartmentService.Services;

internal class DepartmentCrudService : IDepartmentCrudService {
    private IDbContextFactory<DepartmentsDbContext> _contextFactory;
    private IMapper _mapper;

    public DepartmentCrudService(IDbContextFactory<DepartmentsDbContext> contextFactory, IMapper mapper) {
        _contextFactory = contextFactory;
        _mapper = mapper;
    }
    public async Task CreateAsync(DepartmentCrudDto entity, CancellationToken cancellationToken = default) {
        await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var department = _mapper.Map<Department>(entity);
        await context.Departments.AddAsync(department, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(DepartmentCrudDto entity, CancellationToken cancellationToken = default) {
        await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);    
        var department = _mapper.Map<Department>(entity);
        context.Departments.Remove(department);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<DepartmentCrudDto> GetAsync(int id, CancellationToken cancellationToken = default) {
        await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var department = _mapper.Map<DepartmentCrudDto>(await context.Departments.FindAsync(id, cancellationToken));
        return _mapper.Map<DepartmentCrudDto>(department);
    }

    public async Task UpdateAsync(DepartmentCrudDto entity, CancellationToken cancellationToken = default) {
        await using var context = await _contextFactory.CreateDbContextAsync(cancellationToken);
        var department = _mapper.Map<Department>(entity);
        context.Entry(department).State = EntityState.Modified;
        context.Update(department);
    }
}