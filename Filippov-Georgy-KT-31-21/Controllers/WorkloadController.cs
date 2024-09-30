using Filippov_Georgy_KT_31_21.Entities;
using Filippov_Georgy_KT_31_21.Filters.Models;
using Filippov_Georgy_KT_31_21.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Filippov_Georgy_KT_31_21.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class WorkloadController : Controller {
        private readonly ILogger<WorkloadController> _logger;   
        private readonly IWorkloadService _workloadService;

        public WorkloadController(ILogger<WorkloadController> logger, IWorkloadService workloadService) {
            _logger = logger;
            _workloadService = workloadService;
        }

        [HttpPost(Name = "CreateWorkload")]
        public async Task<IActionResult> CreateWorkloadAsync(Workload workload, CancellationToken cancellationToken = default) {
            await _workloadService.CreateAsync(workload, cancellationToken);

            return Ok();
        }

        [HttpGet(Name = "GetWorkloads")]
        public async Task<IActionResult> GetWorkloads([FromQuery]WorkloadFilterModel filter, CancellationToken cancellationToken = default) {
            var res = await _workloadService.GetAsync(filter, cancellationToken);

            return Ok(res);
        }

        [HttpPut(Name = "UpdateWorkload")]
        public async Task<IActionResult> UpdateWorkloadAsync(Workload workload, CancellationToken cancellationToken = default) { 
            await _workloadService.UpdateAsync(workload, cancellationToken);

            return Ok();
        }

        [HttpDelete(Name = "DeleteWorkload")]
        public async Task<IActionResult> DeleteWorkloadAsync(Workload workload, CancellationToken cancellationToken = default) {
            await _workloadService.DeleteAsync(workload, cancellationToken);

            return Ok();
        }
    }
}
