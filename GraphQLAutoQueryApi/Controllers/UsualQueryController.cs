using System.Threading.Tasks;
using Business.Models;
using Business.UsualQueryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GraphQLAutoQueryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsualQueryController : ControllerBase
    {
        private readonly ILogger<UsualQueryController> _logger;
        private readonly IUsualQueryService usualQueryService;

        public UsualQueryController(ILogger<UsualQueryController> logger,
            IUsualQueryService usualQueryService)
        {
            _logger = logger;
            this.usualQueryService = usualQueryService;
        }

        [HttpPost]
        public async Task<IActionResult> Query([FromBody] UsualQueryModels.Request request)
        {
            return Ok(await usualQueryService.QueryAsync(request));
        }
    }
}
