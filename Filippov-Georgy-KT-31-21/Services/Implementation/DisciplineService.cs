using Filippov_Georgy_KT_31_21.Context;
using Filippov_Georgy_KT_31_21.Entities;
using Filippov_Georgy_KT_31_21.Filters.Extensions;
using Filippov_Georgy_KT_31_21.Filters.Models;
using Filippov_Georgy_KT_31_21.Services.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Filippov_Georgy_KT_31_21.Services.Implementation
{
    public class DisciplineService : IDisciplineService {
        private readonly IDbContextFactory<StudyDbContext> _dbContextFactory;

        public DisciplineService(IDbContextFactory<StudyDbContext> dbContextFactory) {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Discipline[]> GetAsync(FilterModel<Discipline> filter, CancellationToken cancellationToken = default) {
            using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken)) {
                return await context.Workloads
                    .AsNoTracking()
                    .Include(wl => wl.Discipline)
                    .Include(wl => wl.Teacher)
                    .Filter(filter)
                    .ToListAsync(cancellationToken);
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
}