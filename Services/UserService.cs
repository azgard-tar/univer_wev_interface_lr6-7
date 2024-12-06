public class UserService : IUserService
{
    private readonly List<User> _users;

    public UserService()
    {
        _users = new List<User>
        {
            new() { Id = Guid.NewGuid(), FullName = "Big Boss", Email = "big.boss@gmail.com", WorkingHours = "09:00 - 18:00", TimeZone = "UTC+2", Role = "Manager" },
            new() { Id = Guid.NewGuid(), FullName = "First Dev", Email = "dev.1@example.com", WorkingHours = "10:00 - 19:00", TimeZone = "UTC-5", Role = "Developer" },
            new() { Id = Guid.NewGuid(), FullName = "Second Dev", Email = "dev.2@example.com", WorkingHours = "09:00 - 18:00", TimeZone = "UTC-5", Role = "Developer" },
            new() { Id = Guid.NewGuid(), FullName = "Third Dev", Email = "dev.3@example.com", WorkingHours = "10:00 - 19:00", TimeZone = "UTC-5", Role = "Developer" },
            new() { Id = Guid.NewGuid(), FullName = "Fourth Dev", Email = "dev.4@example.com", WorkingHours = "09:00 - 18:00", TimeZone = "UTC-5", Role = "Developer" },
            new() { Id = Guid.NewGuid(), FullName = "Fivth Dev", Email = "dev.5@example.com", WorkingHours = "09:00 - 18:00", TimeZone = "UTC-5", Role = "Developer" },
            new() { Id = Guid.NewGuid(), FullName = "Sixth Dev", Email = "dev.6@example.com", WorkingHours = "15:00 - 00:00", TimeZone = "UTC-5", Role = "Developer" },
            new() { Id = Guid.NewGuid(), FullName = "Seventh Dev", Email = "dev.7@example.com", WorkingHours = "15:00 - 00:00", TimeZone = "UTC-5", Role = "Developer" },
            new() { Id = Guid.NewGuid(), FullName = "Eighth Dev", Email = "dev.8@example.com", WorkingHours = "09:00 - 18:00", TimeZone = "UTC-5", Role = "Developer" },
            new() { Id = Guid.NewGuid(), FullName = "Nineth Dev", Email = "dev.9@example.com", WorkingHours = "09:00 - 18:00", TimeZone = "UTC-5", Role = "Developer" },
        };
    }

    public Task<List<User>> GetAllAsync() => Task.FromResult(_users);

    public Task<User> GetByIdAsync(Guid id) => Task.FromResult(_users.FirstOrDefault(u => u.Id == id));

    public Task<User> CreateAsync(CreateUser user)
    {
        if (_users.Any(u => u.Email == user.Email)) throw new ArgumentException("User with this email is already exist.");
        var newUser = new User
        {
          Id = Guid.NewGuid(),
          FullName = user.FullName,
          Email  = user.FullName,
          Role = user.FullName,
          WorkingHours = user.FullName,
          TimeZone = user.FullName,
        };
        _users.Add(newUser);
        return Task.FromResult(newUser);
    }

    public Task<User> UpdateAsync(Guid id, UpdateUser user)
    {
        var existing = _users.FirstOrDefault(u => u.Id == id);
        if (existing == null) throw new ArgumentException("User was not found.");

        if (!string.IsNullOrEmpty(user.FullName)) existing.FullName = user.FullName;
        if (!string.IsNullOrEmpty(user.Email)) existing.Email = user.Email;
        if (!string.IsNullOrEmpty(user.WorkingHours)) existing.WorkingHours = user.WorkingHours;
        if (!string.IsNullOrEmpty(user.TimeZone)) existing.TimeZone = user.TimeZone;
        if (!string.IsNullOrEmpty(user.Role)) existing.Role = user.Role;

        return Task.FromResult(existing);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null) return Task.FromResult(false);

        _users.Remove(user);
        return Task.FromResult(true);
    }
}