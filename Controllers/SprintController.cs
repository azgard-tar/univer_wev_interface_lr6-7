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
    public async Task<IActionResult> Create([FromBody] Sprint sprint)
    {
        var result = await _sprintService.CreateAsync(sprint);
        if (!result) return BadRequest("A sprint with the same name already exists.");
        return Ok(sprint);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Sprint sprint)
    {
        var result = await _sprintService.UpdateAsync(id, sprint);
        if (!result) return NotFound();
        return Ok(sprint);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _sprintService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}