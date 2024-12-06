using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class SprintController : ControllerBase
{
    private readonly ISprintService _sprintService;

    public SprintController(ISprintService sprintService)
    {
        _sprintService = sprintService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var sprints = await _sprintService.GetAllAsync();
        return Ok(sprints);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var sprint = await _sprintService.GetByIdAsync(id);
        if (sprint == null) return NotFound();
        return Ok(sprint);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSprint sprint)
    {
        return Ok(await _sprintService.CreateAsync(sprint));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSprint sprint)
    {
        var result = await _sprintService.UpdateAsync(id, sprint);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _sprintService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}