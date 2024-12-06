public class UpdateTicket
{
  public string? Number { get; set; }
  public string? Title { get; set; }
  public string? Description { get; set; }
  public string? Status { get; set; }
  public string? Priority { get; set; }
  public Guid? ReporterId { get; set; }
  public Guid? AssigneeId { get; set; }
  public double? Estimate { get; set; }
}