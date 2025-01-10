using Filippov_Georgy_KT_31_21.TeacherService.DTOs;

namespace Filippov_Georgy_KT_31_21.DepartmentService.DTOs;

public class DepartmentCrudDto {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime FoundationDate { get; set; }
    public int HeadId { get; set; }
    public TeacherDto Head { get; set; } = null!;
}