namespace Personnel.Domain.Entities;

public class Person
{
    public Guid Id { get; set; }
    public required PersonName Name {get;set; }
    public required Email Email {get;set; }
    public required Phone Phone {get;set; }
    public DateTime DateOfBirth {get;set; }
    public string? AvatarUrl {get;set; }
    public required Gender Gender {get;set; }
    public string? Description {get;set; }
    
    public List<WorkExperience> WorkExperiences {get;set; }
    

}