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
        // Arrange
        var person = CreatePerson();
        var newName = new PersonName("Артем", "Кулебякович", "Маковей");

        // Act
        person.SetPersonName(newName);

        // Assert
        Assert.Equal("Артем", person.Name.FirstName);
        Assert.Equal("Маковей", person.Name.LastName);
        Assert.Equal("Кулебякович", person.Name.MiddleName);
    }

    [Fact]
    public void ChangeEmail()
    {
        // Arrange
        var person = CreatePerson();
        var newEmail = new Email("kulebyaka@brat.com");

        // Act
        person.SetEmail(newEmail);

        // Assert
        Assert.Equal("kulebyaka@brat.com", person.Email.Value);
    }

    [Fact]
    public void ChangePhone()
    {
        // Arrange
        var person = CreatePerson();
        var newPhone = new Phone("77896541");

        // Act
        person.SetPhone(newPhone);

        // Assert
        Assert.Equal("77896541", person.Phone.Value);
    }

    [Fact]
    public void ChangeGender()
    {
        // Arrange
        var person = CreatePerson();

        // Act
        person.SetGender(Gender.Female);

        // Assert
        Assert.Equal(Gender.Female, person.Gender);
    }

    [Fact]
    public void ChangeAvatar()
    {
        // Arrange
        var person = CreatePerson();
        var newAvatar = "avatar.jpg";

        // Act
        person.SetAvatar(newAvatar);

        // Assert
        Assert.Equal("avatar.jpg", person.AvatarUrl);
    }

    [Fact]
    public void ChangeDateOfBirth()
    {
        // Arrange
        var person = CreatePerson();
        var newDateOfBirth = new DateTime(2002, 12, 21);

        // Act
        person.SetDateOfBirth(newDateOfBirth);

        // Assert
        Assert.Equal(newDateOfBirth, person.DateOfBirth);
    }

    [Fact]
    public void AddWorkExperience()
    {
        // Arrange
        var person = CreatePerson();
        var exp = CreateWorkExperience();

        // Act
        person.AddOrUpdateWorkExperience(exp);

        // Assert
        Assert.Single(person.WorkExperiences);
        Assert.Equal("Ведущий разработчик", person.WorkExperiences.First().Position);
    }

    [Fact]
    public void ChangeWorkExperience()
    {
        // Arrange
        var person = CreatePerson();
        var exp = CreateWorkExperience();
        person.AddOrUpdateWorkExperience(exp);

        // Act
        exp.SetPosition("Team Lead");
        exp.SetOrganization("Фисташка");
        person.AddOrUpdateWorkExperience(exp);

        // Assert
        var result = person.WorkExperiences.First();
        Assert.Equal("Team Lead", result.Position);
        Assert.Equal("Фисташка", result.Organization);
    }

    [Fact]
    public void RemoveWorkExperience()
    {
        // Arrange
        var person = CreatePerson();
        var exp = CreateWorkExperience();
        person.AddOrUpdateWorkExperience(exp);

        // Act
        person.RemoveWorkExperience(exp.WorkExperienceId);

        // Assert
        Assert.Empty(person.WorkExperiences);
    }
}
