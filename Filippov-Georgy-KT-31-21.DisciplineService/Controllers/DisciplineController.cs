using AutoMapper;

using Filippov_Georgy_KT_31_21.DisciplineService.DTOs;
using Filippov_Georgy_KT_31_21.DisciplineService.UseCases;

using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
public class DisciplineController : ControllerBase {
    private readonly GetDisciplinesByFilterQuery _getDisciplinesByFilterQuery;
    private readonly UpdateDisciplineCommand _updateDisciplineCommand;
    private readonly CreateDisciplineCommand _createDisciplineCommand;
    private readonly DeleteDisciplineCommand _deleteDisciplineCommand;

    public DisciplineController(GetDisciplinesByFilterQuery getDisciplinesByFilterQuery, UpdateDisciplineCommand updateDisciplineCommand, CreateDisciplineCommand createDisciplineCommand, DeleteDisciplineCommand deleteDisciplineCommand) {
        _getDisciplinesByFilterQuery = getDisciplinesByFilterQuery;
        _updateDisciplineCommand = updateDisciplineCommand;
        _createDisciplineCommand = createDisciplineCommand;
        _deleteDisciplineCommand = deleteDisciplineCommand;
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDiscipline(DisciplineDto disciplineDto) {
        await _updateDisciplineCommand.ExecuteAsync(disciplineDto);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDiscipline(DisciplineDto disciplineDto) {
        await _deleteDisciplineCommand.ExecuteAsync(disciplineDto);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateDiscipline(DisciplineDto disciplineDto) {
        await _createDisciplineCommand.ExecuteAsync(disciplineDto);
        return Ok();
    }

    // public async Task<ActionResult<DisciplineDto[]>> ExecuteAsync(GetDisciplineFilterDto filterDto) {
    //     return Ok(await _getDisciplinesByFilterQuery.ExecuteAsync(filterDto));
    // }
}