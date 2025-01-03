namespace Filippov_Georgy_KT_31_21.Entities {
    public class Discipline : AEntity {
        public string Name { get; set; } = string.Empty;

        public int DepartmentId { get; set; }

        public Department Department { get; set; } = null!;
    }
}
