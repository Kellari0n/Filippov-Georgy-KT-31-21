using Filippov_Georgy_KT_31_21.Filters.Models;
using Filippov_Georgy_KT_31_21.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Filippov_Georgy_KT_31_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiscilplineController : ControllerBase {
        private readonly ILogger<DiscilplineController> _logger;
        private readonly IDisciplineService _disciplineService;

        public DiscilplineController(ILogger<DiscilplineController> logger, IDisciplineService disciplineService) {
            _disciplineService = disciplineService;
            _logger = logger;
        }

        [HttpPost(Name = "GetTeachersByFilter")]
        public async Task<IActionResult> GetTeachersAsync(DisciplineFilterModel filter, CancellationToken cancellationToken = default) {
            var disciplines = await _disciplineService.GetAsync(filter, cancellationToken);
            return Ok(disciplines);
        }
    }
}
