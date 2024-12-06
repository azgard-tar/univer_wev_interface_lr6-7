public class UserService : IUserService
{
    private readonly List<User> _users;

    public UserService()
    {
        _users = new List<User>
        {
            new() { Id = Guid.NewGuid(), FullName = "John Doe", Email = "john.doe@example.com", WorkingHours = 8, TimeZone = "UTC+2", Role = "Manager" },
            new() { Id = Guid.NewGuid(), FullName = "Jane Smith", Email = "jane.smith@example.com", WorkingHours = 8, TimeZone = "UTC-5", Role = "Developer" },
            // Add more users
        };
    }

    public Task<List<User>> GetAllAsync() => Task.FromResult(_users);

    public Task<User> GetByIdAsync(Guid id) => Task.FromResult(_users.FirstOrDefault(u => u.Id == id));

    public Task<bool> CreateAsync(User user)
    {
        if (_users.Any(u => u.Email == user.Email)) return Task.FromResult(false);
        user.Id = Guid.NewGuid();
        _users.Add(user);
        return Task.FromResult(true);
    }

    public Task<bool> UpdateAsync(Guid id, User user)
    {
        var existing = _users.FirstOrDefault(u => u.Id == id);
        if (existing == null) return Task.FromResult(false);

        existing.FullName = user.FullName;
        existing.Email = user.Email;
        existing.WorkingHours = user.WorkingHours;
        existing.TimeZone = user.TimeZone;
        existing.Role = user.Role;

        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null) return Task.FromResult(false);

        _users.Remove(user);
        return Task.FromResult(true);
    }
}