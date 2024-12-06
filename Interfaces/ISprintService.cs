public interface ISprintService
{
  Task<List<Sprint>> GetAllAsync();
  Task<Sprint> GetByIdAsync(Guid id);
  Task<bool> CreateAsync(Sprint sprint);
  Task<bool> UpdateAsync(Guid id, Sprint sprint);
  Task<bool> DeleteAsync(Guid id);
}