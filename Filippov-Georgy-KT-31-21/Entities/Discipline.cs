namespace Filippov_Georgy_KT_31_21.Entities {
    public class Discipline : IEntity {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int DepartmentId { get; set; }

        public Department Department { get; set; } = null!;
    }
}
