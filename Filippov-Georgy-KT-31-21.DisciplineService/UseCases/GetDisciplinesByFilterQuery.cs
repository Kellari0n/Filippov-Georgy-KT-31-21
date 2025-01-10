using AutoMapper;

using DisciplineService;

using Filippov_Georgy_KT_31_21.DisciplineService.DTOs;
using Filippov_Georgy_KT_31_21.Services.Shared.Entities;

using Microsoft.EntityFrameworkCore;

namespace Filippov_Georgy_KT_31_21.DisciplineService.UseCases;

public class GetDisciplinesByFilterQuery {
    private IMapper _mapper;
    private IDbContextFactory<DisciplineDbContext> _dbFactory;

    public GetDisciplinesByFilterQuery(IMapper mapper, IDbContextFactory<DisciplineDbContext> dbFactory) {
        _mapper = mapper;
        _dbFactory = dbFactory;
    }

    // public async Task<DisciplineDto[]> ExecuteAsync(GetDisciplineFilterDto filterDto) {
    //     
    // }
}