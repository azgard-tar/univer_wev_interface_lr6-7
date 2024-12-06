public interface ISprintService
{
  Task<List<Sprint>> GetAllAsync();
  Task<Sprint> GetByIdAsync(Guid id);
  Task<Sprint> CreateAsync(CreateSprint sprint);
  Task<Sprint> UpdateAsync(Guid id, UpdateSprint sprint);
  Task<bool> DeleteAsync(Guid id);
}