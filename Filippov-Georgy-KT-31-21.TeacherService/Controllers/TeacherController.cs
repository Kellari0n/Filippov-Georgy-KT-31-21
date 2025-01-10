using AutoMapper;

using Filippov_Georgy_KT_31_21.TeacherService.DTOs;
using Filippov_Georgy_KT_31_21.TeacherService.Entities;
using Filippov_Georgy_KT_31_21.TeacherService.UseCases;

using Microsoft.AspNetCore.Mvc;

namespace Filippov_Georgy_KT_31_21.TeacherService.Controllers;

[ApiController]
public class TeacherController : ControllerBase {
    private readonly GetTeachersByFilterQuery _getTeachersByFilterQueryQuery;
    
    public TeacherController(GetTeachersByFilterQuery getTeachersByFilterQueryQuery) {
        _getTeachersByFilterQueryQuery = getTeachersByFilterQueryQuery;
    }

    [HttpGet("api/teachers")]
    public async Task<ActionResult<IEnumerable<TeacherDto>>> GetTeachers([FromQuery] GetTeachersFilterDto filter) { 
        return Ok(await _getTeachersByFilterQueryQuery.ExecuteAsync(filter));
    }
}