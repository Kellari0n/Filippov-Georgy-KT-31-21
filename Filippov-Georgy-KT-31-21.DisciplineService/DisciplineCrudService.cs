using DisciplineService;

using Filippov_Georgy_KT_31_21.Services.Shared.Entities;

using Filippov_Georgy_KT_31_21.Services.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Filippov_Georgy_KT_31_21.Services.Implementation;

public class DisciplineCrudService : IDisciplineCrudService {
    private readonly IDbContextFactory<DisciplineDbContext> _dbContextFactory;

    public DisciplineCrudService(IDbContextFactory<DisciplineDbContext> dbContextFactory) {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<Discipline> GetAsync(int id, CancellationToken cancellationToken = default) {
        using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken)) {
            return await context.Disciplines
                .AsNoTracking()
                .FirstAsync(cancellationToken);
        }
    }

    public async Task UpdateAsync(Discipline entity, CancellationToken cancellationToken = default) {
        using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken)) { 
            context.Update(entity);
            await context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task CreateAsync(Discipline entity, CancellationToken cancellationToken = default) {
        using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken)) {
            await context.AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task DeleteAsync(Discipline entity, CancellationToken cancellationToken = default) {
        using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken)) { 
            context.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}