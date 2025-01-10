namespace Filippov_Georgy_KT_31_21.TeacherService.DTOs;

public class TeacherDto {
    public int Id { get; set; }
    
    public FullName Name { get; set; }

    public DateTime Birthdate { get; set; }

    public DateTime EmploymentDate { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public int? DegreeId { get; set; }

    public DegreeDto Degree { get; set; } = null!;

    public int PostId { get; set; }

    public PostDto Post { get; set; } = null!;
    
    public int DepartmentId { get; set; }
    
    public struct FullName {
        public string SecondName { get; set; }

        public string FirstName { get; set; }

        public string? LastName { get; set; }
    }
}