public class CreateSprint
{
    public required string Name { get; set; }
    public List<Guid> TicketIds { get; set; } = new();
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}