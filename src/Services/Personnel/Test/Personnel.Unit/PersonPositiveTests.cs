using Personnel.Domain.Entities;
using Personnel.Domain.Entities.PersonalData;

namespace Personnel.Unit;

public class PersonPositiveTests
{
    private Person CreatePerson()
    {
        var name = new PersonName("Брат", "Братский", "Братович");
        var email = new Email("brat@brat.com");
        var phone = new Phone("77896784");
        var description = "брат братский";
        var avatar = "avatar.png";
        var dateOfBirth = new DateTime(2004, 04, 06);
        
        return new Person(name, Gender.Male, email, phone, dateOfBirth, avatar, description);
    }

    private WorkExperience CreateWorkExperience()
    {
        var address = new Address("PMR", "Tiraspol");
        return new WorkExperience(
            "Ведущий разработчик",
            "ООО 'БратЛэнд'",
            address,
            "Брат братский",
            new DateTime(2021, 04, 06),
            new DateTime(2024, 05, 24));
    }
    
    [Fact]
    public void ChangePersonName()
    {
        var person = CreatePerson();
        var newName = new PersonName("Артем","Кулебякович", "Маковей");
        
        person.SetPersonName(newName);
        
        Assert.Equal("Артем", person.Name.FirstName);
        Assert.Equal("Маковей", person.Name.LastName);
        Assert.Equal("Кулебякович", person.Name.MiddleName);
    }
    
    [Fact]
    public void ChangeEmail()
    {
        var person = CreatePerson();
        var newEmail = new Email("kulebyaka@brat.com");
        
        person.SetEmail(newEmail);
        
        Assert.Equal("kulebyaka@brat.com", person.Email.Value);
    }
    
    [Fact]
    public void ChangePhone()
    {
        var person = CreatePerson();
        var newPhone = new Phone("77896541");
        
        person.SetPhone(newPhone);
        
        Assert.Equal("77896541", person.Phone.Value);
    }
    
    [Fact]
    public void ChangeGender()
    {
        var person = CreatePerson();
        
        person.SetGender(Gender.Female);
        
        Assert.Equal(Gender.Female, person.Gender);
    }
    
    [Fact]
    public void ChangeAvatar()
    {
        var person = CreatePerson();
        var newAvatar = "avatar.jpg";
        
        person.SetAvatar(newAvatar);
        
        Assert.Equal(Gender.Male, person.Gender);
    }
    
    [Fact]
    public void ChangeDateOfBirth()
    {
        var person = CreatePerson();
        var newDateOfBirth = new DateTime(2002, 12, 21);
        
        person.SetDateOfBirth(newDateOfBirth);
        
        Assert.Equal(newDateOfBirth, person.DateOfBirth);
    }
    
    [Fact]
    public void AddWorkExperience()
    {
        var person = CreatePerson();
        var exp = CreateWorkExperience();
        
        person.AddOrUpdateWorkExperience(exp);
        
        Assert.Single(person.WorkExperiences);
        Assert.Equal("Ведущий разработчик", person.WorkExperiences.First().Position);
    }
    
    [Fact]
    public void ChangeWorkExperience()
    {
        var person = CreatePerson();
        var exp = CreateWorkExperience();
        person.AddOrUpdateWorkExperience(exp);
        
        exp.SetPosition("Team Lead");
        exp.SetOrganization("Фисташка"); 
        
        person.AddOrUpdateWorkExperience(exp);
        
        var result = person.WorkExperiences.First();
        
        Assert.Equal("Team Lead", result.Position);
        Assert.Equal("Фисташка", result.Organization);
    }
    
    [Fact]
    public void RemoveWorkExperience()
    {
        var person = CreatePerson();
        var exp = CreateWorkExperience();
        person.AddOrUpdateWorkExperience(exp);
        
        person.RemoveWorkExperience(exp.WorkExperienceId);
        
        Assert.Empty(person.WorkExperiences);
    }
    
    
    
    
}