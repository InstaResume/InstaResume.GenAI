using Microsoft.AspNetCore.Mvc;

namespace InstaResume.GenAI.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    private readonly ILogger<HealthController> _logger;

    public HealthController(ILogger<HealthController> logger)
    {
        _logger = logger;
    }

    [HttpGet("test")]
    public ActionResult GetHealth()
    {
        return Ok();
    }

    [HttpGet("liveness")]
    public ActionResult GetLivenessProbe()
    {
        return Ok();
    }
}