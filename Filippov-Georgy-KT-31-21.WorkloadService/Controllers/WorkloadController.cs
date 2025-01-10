using Microsoft.AspNetCore.Mvc;

namespace Filippov_Georgy_KT_31_21.WorkloadService.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkloadController : Controller {
    private readonly ILogger<WorkloadController> _logger;
    private readonly IWorkloadCrudService _workloadCrudService;

    public WorkloadController(ILogger<WorkloadController> logger, IWorkloadCrudService workloadCrudService) {
        _logger = logger;
        _workloadCrudService = workloadCrudService;
    }

    [HttpPost(Name = "CreateWorkload")]
    public async Task<IActionResult> CreateWorkloadAsync(Workload workload, CancellationToken cancellationToken = default) {
        await _workloadCrudService.CreateAsync(workload, cancellationToken);

        return Ok();
    }

    [HttpGet(Name = "GetWorkloads")]
    public async Task<IActionResult> GetWorkloads([FromQuery] WorkloadFilterModel filter, CancellationToken cancellationToken = default) {
        var res = await _workloadCrudService.GetAsync(filter, cancellationToken);

        return Ok(res);
    }

    [HttpPut(Name = "UpdateWorkload")]
    public async Task<IActionResult> UpdateWorkloadAsync(Workload workload, CancellationToken cancellationToken = default) {
        await _workloadCrudService.UpdateAsync(workload, cancellationToken);

        return Ok();
    }

    [HttpDelete(Name = "DeleteWorkload")]
    public async Task<IActionResult> DeleteWorkloadAsync(Workload workload, CancellationToken cancellationToken = default) {
        await _workloadCrudService.DeleteAsync(workload, cancellationToken);

        return Ok();
    }
}