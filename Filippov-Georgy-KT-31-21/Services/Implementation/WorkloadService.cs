using Filippov_Georgy_KT_31_21.Context;
using Filippov_Georgy_KT_31_21.Entities;
using Filippov_Georgy_KT_31_21.Filters.Extensions;
using Filippov_Georgy_KT_31_21.Filters.Models;
using Filippov_Georgy_KT_31_21.Services.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Filippov_Georgy_KT_31_21.Services.Implementation
{
    internal class WorkloadService : IWorkloadService {
        private IDbContextFactory<StudyDbContext> _dbContextFactory;
        public WorkloadService(IDbContextFactory<StudyDbContext> dbContextFactory) {
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

        public async Task<I<Workload>> GetAsync(FilterModel<Workload> filter, CancellationToken cancellationToken = default) {
            using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken)) {
                return await context.Workloads
                    .AsNoTracking()
                    .Include(wl => wl.Teacher)
                    .Include(wl => wl.Discipline)
                    .Filter(filter)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
