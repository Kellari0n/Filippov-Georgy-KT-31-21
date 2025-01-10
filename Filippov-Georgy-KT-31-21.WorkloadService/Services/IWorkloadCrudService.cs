using Filippov_Georgy_KT_31_21.Services.Shared.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Filippov_Georgy_KT_31_21.WorkloadService;

public interface IWorkloadCrudService : ICrudService<Workload> {
    public Task<Workload[]> GetAsync(WorkloadFilterModel filter, CancellationToken cancellationToken = default);
}