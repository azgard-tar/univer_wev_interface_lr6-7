public class TicketService : ITicketService
{
  private readonly List<Ticket> _tickets;
  private readonly List<User> _users;

  public TicketService(IUserService userService)
  {
    _users = userService.GetAllAsync().Result;
    _tickets = new List<Ticket>
        {
            new() { Id = Guid.NewGuid(), Number = "TKT-001", Title = "Bug fix", Description = "Fix login issue", Status = "Open", Priority = "High", CreatedAt = DateTime.Now.AddDays(-30), UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[1].Id, Estimate = 2.5 },
            new() { Id = Guid.NewGuid(), Number = "TKT-002", Title = "UI Improvement", Description = "Improve header design", Status = "Open", Priority = "Medium", CreatedAt = DateTime.Now.AddDays(-25), UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[2].Id, Estimate = 3 },
            new() { Id = Guid.NewGuid(), Number = "TKT-003", Title = "API Optimization", Description = "Optimize API response time", Status = "In Progress", Priority = "High", CreatedAt = DateTime.Now.AddDays(-15), UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[3].Id, Estimate = 5 },
            new() { Id = Guid.NewGuid(), Number = "TKT-004", Title = "Database Migration", Description = "Migrate database to new server", Status = "Open", Priority = "Low", CreatedAt = DateTime.Now.AddDays(-60), UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[4].Id, Estimate = 10 },
            new() { Id = Guid.NewGuid(), Number = "TKT-005", Title = "Security Update", Description = "Apply latest security patches", Status = "Open", Priority = "High", CreatedAt = DateTime.Now.AddDays(-40), UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[5].Id, Estimate = 4 },
            new() { Id = Guid.NewGuid(), Number = "TKT-006", Title = "Feature Development", Description = "Develop new user authentication feature", Status = "In Progress", Priority = "Medium", CreatedAt = DateTime.Now.AddDays(-10), UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[6].Id, Estimate = 15 },
            new() { Id = Guid.NewGuid(), Number = "TKT-007", Title = "Code Refactoring", Description = "Refactor legacy code", Status = "Completed", Priority = "Low", CreatedAt = DateTime.Now.AddDays(-5), UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[7].Id, Estimate = 7 },
            new() { Id = Guid.NewGuid(), Number = "TKT-008", Title = "Bug fix", Description = "Fix login issue", Status = "Open", Priority = "High", CreatedAt = DateTime.Now.AddDays(-45), UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[8].Id, Estimate = 2.5 },
            new() { Id = Guid.NewGuid(), Number = "TKT-009", Title = "API Security", Description = "Implement API authentication", Status = "In Progress", Priority = "Medium", CreatedAt = DateTime.Now.AddDays(-20), UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[1].Id, Estimate = 6 },
            new() { Id = Guid.NewGuid(), Number = "TKT-010", Title = "Performance Tuning", Description = "Optimize database queries", Status = "Open", Priority = "High", CreatedAt = DateTime.Now.AddDays(-30), UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[2].Id, Estimate = 5 },
            new() { Id = Guid.NewGuid(), Number = "TKT-011", Title = "Feature Testing", Description = "Test new login feature", Status = "Completed", Priority = "Medium", CreatedAt = DateTime.Now.AddDays(-35), UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[3].Id, Estimate = 4 },
            new() { Id = Guid.NewGuid(), Number = "TKT-012", Title = "Bug fix", Description = "Fix issue with user permissions", Status = "Open", Priority = "High", CreatedAt = DateTime.Now.AddDays(-50), UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[4].Id, Estimate = 3 },
            new() { Id = Guid.NewGuid(), Number = "TKT-013", Title = "UI Design", Description = "Redesign the settings page", Status = "In Progress", Priority = "Low", CreatedAt = DateTime.Now.AddDays(-14), UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[5].Id, Estimate = 8 },
            new() { Id = Guid.NewGuid(), Number = "TKT-014", Title = "Bug fix", Description = "Fix crash on user profile page", Status = "Completed", Priority = "High", CreatedAt = DateTime.Now.AddDays(-25), UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[6].Id, Estimate = 3.5 },
            new() { Id = Guid.NewGuid(), Number = "TKT-015", Title = "Database Optimization", Description = "Optimize indexing for faster queries", Status = "In Progress", Priority = "Medium", CreatedAt = DateTime.Now.AddDays(-7), UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[7].Id, Estimate = 6 },
            new() { Id = Guid.NewGuid(), Number = "TKT-016", Title = "Security Audit", Description = "Perform security audit on the app", Status = "Open", Priority = "High", CreatedAt = DateTime.Now.AddDays(-22), UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[8].Id, Estimate = 10 },
            new() { Id = Guid.NewGuid(), Number = "TKT-017", Title = "Feature Enhancement", Description = "Enhance user profile page", Status = "Completed", Priority = "Low", CreatedAt = DateTime.Now.AddDays(-3), UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[1].Id, Estimate = 7 },
            new() { Id = Guid.NewGuid(), Number = "TKT-018", Title = "Bug fix", Description = "Fix issue with email notifications", Status = "Open", Priority = "High", CreatedAt = DateTime.Now.AddDays(-18), UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[2].Id, Estimate = 4 },
            new() { Id = Guid.NewGuid(), Number = "TKT-019", Title = "Performance Improvement", Description = "Improve application startup time", Status = "In Progress", Priority = "Medium", CreatedAt = DateTime.Now.AddDays(-8), UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[3].Id, Estimate = 5 },
            new() { Id = Guid.NewGuid(), Number = "TKT-020", Title = "Feature Development", Description = "Develop new search functionality", Status = "Open", Priority = "High", CreatedAt = DateTime.Now.AddDays(-35), UpdatedAt = DateTime.Now, ReporterId = _users[0].Id, AssigneeId = _users[4].Id, Estimate = 12 }
        };
  }

  public Task<List<Ticket>> GetAllAsync() => Task.FromResult(_tickets);

  public Task<Ticket> GetByIdAsync(Guid id) => Task.FromResult(_tickets.FirstOrDefault(t => t.Id == id));

  public Task<Ticket> CreateAsync(CreateTicket ticket)
  {
    var newTicket = new Ticket
    {
      Id = Guid.NewGuid(),
      Number = ticket.Number,
      Title = ticket.Title,
      Description = ticket.Description,
      Status = ticket.Status,
      Priority = ticket.Priority,
      CreatedAt = DateTime.Now,
      UpdatedAt = DateTime.Now,
      ReporterId = ticket.ReporterId,
      AssigneeId = ticket.AssigneeId,
      Estimate = ticket.Estimate
    };
    _tickets.Add(newTicket);
    return Task.FromResult(newTicket);
  }

  public Task<Ticket> UpdateAsync(Guid id, UpdateTicket ticket)
  {
    var existing = _tickets.FirstOrDefault(t => t.Id == id);
    if (existing == null) throw new ArgumentException("Ticket was not found.");

    if (!string.IsNullOrEmpty(ticket.Number)) existing.Number = ticket.Number;
    if (!string.IsNullOrEmpty(ticket.Title)) existing.Title = ticket.Title;
    if (!string.IsNullOrEmpty(ticket.Description)) existing.Description = ticket.Description;
    if (!string.IsNullOrEmpty(ticket.Status)) existing.Status = ticket.Status;
    if (!string.IsNullOrEmpty(ticket.Priority)) existing.Priority = ticket.Priority;
    if (ticket.ReporterId != null) existing.ReporterId = (Guid)ticket.ReporterId;
    if (ticket.AssigneeId != null) existing.AssigneeId = (Guid)ticket.AssigneeId;
    if (ticket.Estimate != null) existing.Estimate = (double)ticket.Estimate;
    if (!string.IsNullOrEmpty(ticket.Priority)) existing.Priority = ticket.Priority;
    existing.UpdatedAt = DateTime.Now;

    return Task.FromResult(existing);
  }

  public Task<bool> DeleteAsync(Guid id)
  {
    var ticket = _tickets.FirstOrDefault(t => t.Id == id);
    if (ticket == null) return Task.FromResult(false);

    _tickets.Remove(ticket);
    return Task.FromResult(true);
  }
}