namespace Filippov_Georgy_KT_31_21.Entities {
    public class Teacher {
        public int Id { get; set; }

        public string SecondName { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int? DegreeId { get; set; }

        public Degree Degree { get; set; } = null!;

        public int PostId { get; set; }

        public Post Post { get; set; } = null!;
    }
}
