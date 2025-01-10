namespace Filippov_Georgy_KT_31_21.DisciplineService.DTOs;

public class GetDisciplineFilterDto {
    public int TeacherId { get; set; }
    public int WorkloadStart { get; set; }
    public int WorkloadEnd { get; set; }
}