using Filippov_Georgy_KT_31_21.Services.Shared.Entities;

namespace Filippov_Georgy_KT_31_21.Services.Shared.FilterModels;

public class DisciplineFilterModel {
    public int? HoursRangeStart { get; set; }
    public int? HoursRangeEnd { get; set; }
    public int? TeacherId { get; set; }
    public int? DisciplineId { get; set; }

    public IQueryable<Discipline> Filter(Discipline entity) {
        throw new NotImplementedException();
    }
}