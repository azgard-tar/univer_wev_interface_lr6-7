public interface ITicketService
{
  Task<List<Ticket>> GetAllAsync();
  Task<Ticket> GetByIdAsync(Guid id);
  Task<Ticket> CreateAsync(CreateTicket ticket);
  Task<Ticket> UpdateAsync(Guid id, UpdateTicket ticket);
  Task<bool> DeleteAsync(Guid id);
}