public interface IUserService
{
  Task<List<User>> GetAllAsync();
  Task<User> GetByIdAsync(Guid id);
  Task<bool> CreateAsync(User user);
  Task<bool> UpdateAsync(Guid id, User User);
  Task<bool> DeleteAsync(Guid id);
}