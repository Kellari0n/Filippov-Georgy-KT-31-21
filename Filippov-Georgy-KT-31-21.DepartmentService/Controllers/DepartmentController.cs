using Filippov_Georgy_KT_31_21.DepartmentService.DTOs;
using Filippov_Georgy_KT_31_21.DepartmentService.UseCases;

using Microsoft.AspNetCore.Mvc;

namespace Filippov_Georgy_KT_31_21.DepartmentService.Controllers;

[ApiController]
public class DepartmentController : ControllerBase {
    private readonly GetDepartmentsByFilterQuery _getDepartmentsByFilterQuery;
    
    public DepartmentController(GetDepartmentsByFilterQuery getDepartmentsByFilterQuery) {
        _getDepartmentsByFilterQuery = getDepartmentsByFilterQuery;
    }

    [HttpGet("api/departments")]
    public async Task<ActionResult<IEnumerable<DepartmentCrudDto>>> GetDepartments([FromQuery] GetDepartmentsFilterDto filterDto, CancellationToken cancellationToken = default) {
        return Ok(await _getDepartmentsByFilterQuery.ExecuteAsync(filterDto, cancellationToken));
    }
}