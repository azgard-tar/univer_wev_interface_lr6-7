public interface IUserService
{
  Task<List<User>> GetAllAsync();
  Task<User> GetByIdAsync(Guid id);
  Task<User> CreateAsync(CreateUser user);
  Task<User> UpdateAsync(Guid id, UpdateUser User);
  Task<bool> DeleteAsync(Guid id);
}