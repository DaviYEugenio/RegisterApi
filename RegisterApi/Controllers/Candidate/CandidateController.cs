using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegisterApi.Services.Candidate;
using RegisterApi.Services.Candidate.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace RegisterApi.Controllers.Candidate
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ILogger _logger;
        public CandidateController(ILogger<CandidateController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CandidateRequestViewModel candidateRequestViewModel,
            [FromServices] ICandidateService service)
        {
            try
            {
                var result = await service.Save(candidateRequestViewModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return StatusCode(500);
            }

        }
        [HttpGet]
        public async Task<IActionResult> Action([FromServices] ICandidateService service)
        {
            var result = await service.Get();
            return Ok(result);
        }
    }
}
