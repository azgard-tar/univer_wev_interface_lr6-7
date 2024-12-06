public class SprintService : ISprintService
{
  private readonly List<Sprint> _sprints;
  private readonly List<Ticket> _tickets;

  public SprintService(ITicketService ticketService)
  {
    _tickets = ticketService.GetAllAsync().Result;

    _sprints = new List<Sprint>
        {
          new() { Id = Guid.NewGuid(), Name = "Sprint 1", TicketIds = new List<Guid> { _tickets[0].Id, _tickets[1].Id }, StartTime = DateTime.Now, EndTime = DateTime.Now.AddDays(14) },
          new() { Id = Guid.NewGuid(), Name = "Sprint 2", TicketIds = new List<Guid> { _tickets[2].Id, _tickets[3].Id }, StartTime = DateTime.Now.AddDays(15), EndTime = DateTime.Now.AddDays(29) },
          new() { Id = Guid.NewGuid(), Name = "Sprint 3", TicketIds = new List<Guid> { _tickets[4].Id, _tickets[5].Id }, StartTime = DateTime.Now.AddDays(30), EndTime = DateTime.Now.AddDays(44) },
          new() { Id = Guid.NewGuid(), Name = "Sprint 4", TicketIds = new List<Guid> { _tickets[6].Id, _tickets[7].Id }, StartTime = DateTime.Now.AddDays(45), EndTime = DateTime.Now.AddDays(59) },
          new() { Id = Guid.NewGuid(), Name = "Sprint 5", TicketIds = new List<Guid> { _tickets[8].Id, _tickets[9].Id }, StartTime = DateTime.Now.AddDays(60), EndTime = DateTime.Now.AddDays(74) },
          new() { Id = Guid.NewGuid(), Name = "Sprint 6", TicketIds = new List<Guid> { _tickets[10].Id, _tickets[11].Id }, StartTime = DateTime.Now.AddDays(75), EndTime = DateTime.Now.AddDays(89) },
          new() { Id = Guid.NewGuid(), Name = "Sprint 7", TicketIds = new List<Guid> { _tickets[12].Id, _tickets[13].Id }, StartTime = DateTime.Now.AddDays(90), EndTime = DateTime.Now.AddDays(104) },
          new() { Id = Guid.NewGuid(), Name = "Sprint 8", TicketIds = new List<Guid> { _tickets[14].Id, _tickets[15].Id }, StartTime = DateTime.Now.AddDays(105), EndTime = DateTime.Now.AddDays(119) },
          new() { Id = Guid.NewGuid(), Name = "Sprint 9", TicketIds = new List<Guid> { _tickets[16].Id, _tickets[17].Id }, StartTime = DateTime.Now.AddDays(120), EndTime = DateTime.Now.AddDays(134) },
          new() { Id = Guid.NewGuid(), Name = "Sprint 10", TicketIds = new List<Guid> { _tickets[18].Id, _tickets[19].Id }, StartTime = DateTime.Now.AddDays(135), EndTime = DateTime.Now.AddDays(149) },
        };
  }

  private bool AreAllTicketIdsValid(IEnumerable<Guid> ticketIds)
  {
    return ticketIds.All(id => _tickets.Any(t => t.Id == id));
  }

  public Task<List<Sprint>> GetAllAsync() => Task.FromResult(_sprints);

  public Task<Sprint> GetByIdAsync(Guid id) => Task.FromResult(_sprints.FirstOrDefault(s => s.Id == id));

  public Task<Sprint> CreateAsync(CreateSprint sprint)
  {
    if (_sprints.Any(s => s.Name == sprint.Name)) 
      throw new ArgumentException("Sprint with this name is already exist.");
    if (!AreAllTicketIdsValid(sprint.TicketIds))
      throw new ArgumentException("One or more TicketIds are invalid.");

    var newSprint = new Sprint
    {
      Id = Guid.NewGuid(),
      Name = sprint.Name,
      StartTime = sprint.StartTime,
      EndTime = sprint.EndTime,
      TicketIds = sprint.TicketIds ?? new List<Guid>()
    };

    _sprints.Add(newSprint);
    return Task.FromResult(newSprint);
  }

  public Task<Sprint> UpdateAsync(Guid id, UpdateSprint sprint)
  {
    var existing = _sprints.FirstOrDefault(s => s.Id == id);
    if (existing == null) throw new ArgumentException("Sprint was not found.");

    if (!string.IsNullOrEmpty(sprint.Name)) existing.Name = sprint.Name;
    if (sprint.TicketIds != null)
    {
      if (!AreAllTicketIdsValid(sprint.TicketIds))
        throw new ArgumentException("One or more TicketIds are invalid.");
      existing.TicketIds = sprint.TicketIds;
    }
    if (sprint.StartTime != null && sprint.StartTime.HasValue) existing.StartTime = (DateTime)sprint.StartTime;
    if (sprint.EndTime != null && sprint.EndTime.HasValue) existing.EndTime = (DateTime)sprint.EndTime;

    return Task.FromResult(existing);
  }

  public Task<bool> DeleteAsync(Guid id)
  {
    var sprint = _sprints.FirstOrDefault(s => s.Id == id);
    if (sprint == null) return Task.FromResult(false);

    _sprints.Remove(sprint);
    return Task.FromResult(true);
  }
}