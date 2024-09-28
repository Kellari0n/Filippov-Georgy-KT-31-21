namespace Filippov_Georgy_KT_31_21.Entities {
    public class Workload : IEntity {
        public int Id { get; set; }

        public int StudyHoursCount { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; } = null!;

        public int DisciplineId { get; set; }

        public Discipline Discipline { get; set; } = null!;
    }
}
