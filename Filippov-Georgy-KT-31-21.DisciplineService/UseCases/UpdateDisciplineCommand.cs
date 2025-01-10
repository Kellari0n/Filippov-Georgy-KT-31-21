using AutoMapper;

using DisciplineService;

using Filippov_Georgy_KT_31_21.DisciplineService.DTOs;
using Filippov_Georgy_KT_31_21.Services.Shared.Entities;

using Microsoft.EntityFrameworkCore;

namespace Filippov_Georgy_KT_31_21.DisciplineService.UseCases;

public class UpdateDisciplineCommand {
    private readonly IMapper _mapper;
    private readonly IDbContextFactory<DisciplineDbContext> _dbFactory;

    public UpdateDisciplineCommand(IMapper mapper, IDbContextFactory<DisciplineDbContext> dbFactory) {
        _mapper = mapper;
        _dbFactory = dbFactory;
    }

    public async Task ExecuteAsync(DisciplineDto disciplineDto) {
        await using var db = await _dbFactory.CreateDbContextAsync();
        var discipline = _mapper.Map<Discipline>(disciplineDto);
        db.Disciplines.Update(discipline);
        await db.SaveChangesAsync();
    }
}