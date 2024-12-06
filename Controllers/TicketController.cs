using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tickets = await _ticketService.GetAllAsync();
        return Ok(tickets);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var ticket = await _ticketService.GetByIdAsync(id);
        if (ticket == null) return NotFound();
        return Ok(ticket);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Ticket ticket)
    {
        var result = await _ticketService.CreateAsync(ticket);
        if (!result) return BadRequest("A ticket with the same number already exists.");
        return Ok(ticket);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Ticket ticket)
    {
        var result = await _ticketService.UpdateAsync(id, ticket);
        if (!result) return NotFound();
        return Ok(ticket);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _ticketService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}