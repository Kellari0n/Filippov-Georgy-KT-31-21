using Filippov_Georgy_KT_31_21.Entities;
using Filippov_Georgy_KT_31_21.Filters.Models;

using Microsoft.EntityFrameworkCore;

namespace Filippov_Georgy_KT_31_21.Filters.Extensions {
    public static class DisciplineFilterExtentions {
        public static IQueryable<Discipline> Filter(this IQueryable<Workload> query, FilterModel<Discipline> filter) {
            if (filter.Id is not null) {
                query = query.Where(wl => wl.DisciplineId == filter.Id);
            }

            if (filter is DisciplineFilterModel disciplineFilter) {
                if (disciplineFilter.TeacherId is not null) {
                    query = query.Where(wl => wl.TeacherId == disciplineFilter.TeacherId);
                }

                if (disciplineFilter.HoursRangeStart is not null) {
                    query = query.Where(wl => wl.StudyHoursCount >= disciplineFilter.HoursRangeStart);
                }

                if (disciplineFilter.HoursRangeEnd is not null) {
                    query = query.Where(wl => wl.StudyHoursCount <= disciplineFilter.HoursRangeEnd);
                }
            }

            return query.Select(wl => wl.Discipline);
        }
    }
}
