using Filippov_Georgy_KT_31_21.Entities;
using Filippov_Georgy_KT_31_21.Filters.Models;

namespace Filippov_Georgy_KT_31_21.Filters.Extensions
{
    public static class WorkloadFilterExtentions {
        public static IQueryable<Workload> Filter(this IQueryable<Workload> query, FilterModel<Workload> filter) {
            if (filter.Id is not null) {
                query = query.Where(wl => wl.Id == filter.Id);
            }

            return query;
        }
    }
}
