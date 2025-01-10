using Microsoft.EntityFrameworkCore;

namespace Filippov_Georgy_KT_31_21.WorkloadService;

internal class WorkloadCrudService : IWorkloadCrudService {
    private IDbContextFactory<WorkloadDbContext> _dbContextFactory;
    public WorkloadCrudService(IDbContextFactory<WorkloadDbContext> dbContextFactory) {
        _dbContextFactory = dbContextFactory;
    }

    public async Task CreateAsync(Workload workload, CancellationToken cancellationToken = default) {
        using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken)) {
            await context.AddAsync(workload, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task UpdateAsync(Workload workload, CancellationToken cancellationToken = default) {
        using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken)) {
            context.Update(workload);
            await context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task DeleteAsync(Workload workload, CancellationToken cancellationToken = default) {
        using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken)) {
            context.Remove(workload);
            await context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<Workload[]> GetAsync(WorkloadFilterModel filter, CancellationToken cancellationToken = default) {
        using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken)) {
            return await context.Workloads
                .AsNoTracking()
                .Filter(filter)
                .ToArrayAsync(cancellationToken);
        }
    }

    public async Task<Workload> GetAsync(int id, CancellationToken cancellationToken) {
        using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken)) {
            return await context.Workloads
                .AsNoTracking()
                .FirstAsync(wl => wl.Id == id);
        }
    }
}