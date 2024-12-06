public class Ticket
{
  public required Guid Id { get; set; }
  public required string Number { get; set; }
  public required string Title { get; set; }
  public required string Description { get; set; }
  public required string Status { get; set; }
  public required string Priority { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public Guid ReporterId { get; set; }
  public Guid AssigneeId { get; set; }
  public double Estimate { get; set; }
}