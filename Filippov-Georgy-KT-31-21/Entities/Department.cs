namespace Filippov_Georgy_KT_31_21.Entities {
    public class Department : AEntity {
        public string Name { get; set; } = string.Empty;

        public int HeadId { get; set; }

        public Teacher Head { get; set; } = null!;
    }
}
