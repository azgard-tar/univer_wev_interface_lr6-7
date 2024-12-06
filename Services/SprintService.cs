public class SprintService : ISprintService
{
  private readonly List<Sprint> _sprints;
  private readonly List<Ticket> _tickets;

  public SprintService(ITicketService ticketService)
  {
    // Отримуємо тікети з сервісу тікетів
    _tickets = ticketService.GetAllAsync().Result;

    // Ініціалізуємо список спринтів
    _sprints = new List<Sprint>
        {
            new Sprint
            {
                Id = Guid.NewGuid(),
                Name = "Sprint 1",
                TicketIds = _tickets.Select(t => t.Id).Take(2).ToList(),
                StartTime = DateTime.Now.AddDays(-10),
                EndTime = DateTime.Now.AddDays(-5)
            },
            new Sprint
            {
                Id = Guid.NewGuid(),
                Name = "Sprint 2",
                TicketIds = _tickets.Select(t => t.Id).Skip(2).Take(3).ToList(),
                StartTime = DateTime.Now.AddDays(-4),
                EndTime = DateTime.Now.AddDays(2)
            }
        };
  }

  private bool AreAllTicketIdsValid(IEnumerable<Guid> ticketIds)
  {
    return ticketIds.All(id => _tickets.Any(t => t.Id == id));
  }

  public Task<List<Sprint>> GetAllAsync() => Task.FromResult(_sprints);

  public Task<Sprint> GetByIdAsync(Guid id) => Task.FromResult(_sprints.FirstOrDefault(s => s.Id == id));

  public Task<bool> CreateAsync(Sprint sprint)
  {
    if (_sprints.Any(s => s.Name == sprint.Name)) return Task.FromResult(false);
    if (!AreAllTicketIdsValid(sprint.TicketIds))
      throw new ArgumentException("One or more TicketIds are invalid.");

    sprint.Id = Guid.NewGuid();

    // Додаємо спринт
    _sprints.Add(sprint);
    return Task.FromResult(true);
  }

  public Task<bool> UpdateAsync(Guid id, Sprint sprint)
  {
    var existing = _sprints.FirstOrDefault(s => s.Id == id);
    if (existing == null) return Task.FromResult(false);
    if (!AreAllTicketIdsValid(sprint.TicketIds))
      throw new ArgumentException("One or more TicketIds are invalid.");

    existing.Name = sprint.Name;
    existing.TicketIds = sprint.TicketIds;
    existing.StartTime = sprint.StartTime;
    existing.EndTime = sprint.EndTime;

    return Task.FromResult(true);
  }

  public Task<bool> DeleteAsync(Guid id)
  {
    var sprint = _sprints.FirstOrDefault(s => s.Id == id);
    if (sprint == null) return Task.FromResult(false);

    _sprints.Remove(sprint);
    return Task.FromResult(true);
  }
}