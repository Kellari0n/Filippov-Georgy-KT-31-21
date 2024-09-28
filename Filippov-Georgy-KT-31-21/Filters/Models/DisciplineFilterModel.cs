using Filippov_Georgy_KT_31_21.Entities;

namespace Filippov_Georgy_KT_31_21.Filters.Models
{
    public class DisciplineFilterModel : FilterModel<Discipline>
    {
        public int? HoursRangeStart { get; set; }
        public int? HoursRangeEnd { get; set; }
        public int? TeacherId { get; set; }
        public int? DisciplineId { get; set; }

        public IQueryable<Discipline> Filter(Discipline entity)
        {
            throw new NotImplementedException();
        }
    }
}
