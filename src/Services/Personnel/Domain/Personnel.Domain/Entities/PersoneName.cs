namespace Personnel.Domain.Entities;

public class PersonName
{
    public required string FirstName { get; set; }
    public required string MiddleName { get; set; }
    public string? LastName { get; set; }
}