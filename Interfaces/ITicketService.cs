public interface ITicketService
{
  Task<List<Ticket>> GetAllAsync();
  Task<Ticket> GetByIdAsync(Guid id);
  Task<bool> CreateAsync(Ticket ticket);
  Task<bool> UpdateAsync(Guid id, Ticket ticket);
  Task<bool> DeleteAsync(Guid id);
}