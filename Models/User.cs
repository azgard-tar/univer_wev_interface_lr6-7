public class User
{

  public required Guid Id { get; set; }
  public required string FullName { get; set; }
  public required string Email { get; set; }
  public double WorkingHours { get; set; }
  public string TimeZone { get; set; }
  public string Role { get; set; }
} 