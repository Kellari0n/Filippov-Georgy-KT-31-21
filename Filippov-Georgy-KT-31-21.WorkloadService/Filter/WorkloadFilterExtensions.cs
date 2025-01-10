namespace Filippov_Georgy_KT_31_21.WorkloadService;

public static class WorkloadFilterExtensions {
    public static IQueryable<Workload> Filter(this IQueryable<Workload> query, WorkloadFilterModel filter) {
        if (filter.DepartmentId.HasValue) {
            query = query.Where(w => w.DepartmentId == filter.DepartmentId);
        }
        if (filter.DisciplineId.HasValue) {
            query = query.Where(w => w.DisciplineId == filter.DisciplineId);
        }
        if (filter.TeacherId.HasValue) {
            query = query.Where(w => w.TeacherId == filter.TeacherId);
        }
        
        return query;
    }
}