public class CreateTicket
{
  public required string Number { get; set; }
  public required string Title { get; set; }
  public required string Description { get; set; }
  public required string Status { get; set; }
  public required string Priority { get; set; }
  public Guid ReporterId { get; set; }
  public Guid AssigneeId { get; set; }
  public double Estimate { get; set; }
}