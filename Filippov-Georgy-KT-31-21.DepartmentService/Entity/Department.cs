using Filippov_Georgy_KT_31_21.DepartmentService.DTOs;

namespace Filippov_Georgy_KT_31_21.DepartmentService.Entity;

public class Department {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime FoundationDate { get; set; }
    public int HeadId { get; set; }

    public DepartmentCrudDto ToCrudDto() {
        return new DepartmentCrudDto {
            Id = Id,
            Name = Name,
            HeadId = HeadId
        };
    }
    
    public static Department FromCrudDto(DepartmentCrudDto crudDto) {
        return new Department {
            Id = crudDto.Id,
            Name = crudDto.Name,
            HeadId = crudDto.HeadId
        };
    }
}