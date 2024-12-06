public class TicketService : ITicketService
{
  private readonly List<Ticket> _tickets;
  private readonly List<User> _users;

  public TicketService(IUserService userService)
  {
    _users = userService.GetAllAsync().Result;
    _tickets = new List<Ticket>
        {
            new() { Id = Guid.NewGuid(), Number = "TKT-001", Title = "Bug fix", Description = "Fix login issue", Status = "Open", Priority = "High", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[1].Id, Estimate = 2.5 },
        };
  }

  public Task<List<Ticket>> GetAllAsync() => Task.FromResult(_tickets);

  public Task<Ticket> GetByIdAsync(Guid id) => Task.FromResult(_tickets.FirstOrDefault(t => t.Id == id));

  public Task<bool> CreateAsync(Ticket ticket)
  {
    _tickets.Add(ticket);
    return Task.FromResult(true);
  }

  public Task<bool> UpdateAsync(Guid id, Ticket ticket)
  {
    var existing = _tickets.FirstOrDefault(t => t.Id == id);
    if (existing == null) return Task.FromResult(false);

    existing.Title = ticket.Title;
    existing.Description = ticket.Description;
    existing.Status = ticket.Status;
    existing.Priority = ticket.Priority;
    existing.UpdatedAt = DateTime.Now;

    return Task.FromResult(true);
  }

  public Task<bool> DeleteAsync(Guid id)
  {
    var ticket = _tickets.FirstOrDefault(t => t.Id == id);
    if (ticket == null) return Task.FromResult(false);

    _tickets.Remove(ticket);
    return Task.FromResult(true);
  }
}