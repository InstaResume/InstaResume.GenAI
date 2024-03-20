using InstaResume.GenAI.WebApi.Models;
using InstaResume.GenAI.WebApi.Models.Request;
using InstaResume.GenAI.WebApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InstaResume.GenAI.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DescriptionGeneratorController : ControllerBase
{
    private readonly ILogger<DescriptionGeneratorController> _logger;
    private readonly IDescriptionGeneratorService _descriptionGeneratorService;

    public DescriptionGeneratorController(ILogger<DescriptionGeneratorController> logger,
        IDescriptionGeneratorService descriptionGeneratorService)
    {
        _logger = logger;
        _descriptionGeneratorService = descriptionGeneratorService;
    }

    [HttpPost("create")]
    public async Task<ActionResult<GeneratedDescription>> GetGenDescription(GetGenDescriptionRequest request)
    {
        try
        {
            return Ok(await _descriptionGeneratorService.GenerateDescription(request));
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
    
    [HttpPost("recreate")]
    public async Task<ActionResult<GeneratedDescription>> GetReGenDescription(GetGenDescriptionRequest request)
    {
        try
        {
            return Ok(await _descriptionGeneratorService.GenerateDescription(request));
        }
        catch (Exception e)
        {
            return Problem(e.Message);
        }
    }
}