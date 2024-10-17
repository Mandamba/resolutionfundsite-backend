using Microsoft.AspNetCore.Mvc;
using ResolutionFundSite.Application.DTOs.Response;
using ResolutionFundSite.Domain.Iinterfaces;

namespace ResolutionFundSite.Api.Controllers;
[ApiController]
[Route("comments")]
public class CommentController : ControllerBase
{
    private readonly IComentRepository _comentRepository;
    public CommentController(IComentRepository comentRepository)
    { 
        _comentRepository = comentRepository;
    }

    [HttpGet("getComment")]
    public async Task<ActionResult<List<CommentResponse>>> GetAll()
    {
        var businessSummaryService = await _comentRepository.GetAllAsync();
        return Ok(businessSummaryService);
    }
}