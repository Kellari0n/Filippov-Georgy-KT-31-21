namespace Filippov_Georgy_KT_31_21.DepartmentService.DTOs;

public class GetDepartmentsFilterDto {
    public DateTime? FoundationDateStart { get; set; }
    public DateTime? FoundationDateEnd { get; set; }
    public int? TeachersCountStart { get; set; }
    public int? TeachersCountEnd { get; set; }
}