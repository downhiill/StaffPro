namespace Personnel.Domain.Entities;

public class WorkExperience
{
    public required string Position { get; set; }
    public required string Organization { get; set; }
    public required Address Address { get; set; }  
    public required DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}