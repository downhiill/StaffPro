using Personnel.Domain.Entities;
using Personnel.Domain.Entities.PersonalData;

namespace Personnel.Unit;

public class PersonNegativeTests
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

    [Fact]
    public void SetAvatar_InvalidExtension_ThrowsArgumentException()
    {
        // Arrange
        var person = CreatePerson();

        // Act
        void Act() => person.SetAvatar("avatar.gif");

        // Assert
        Assert.Throws<ArgumentException>(Act);
    }

    [Fact]
    public void WorkExperience_StartDateInFuture_ThrowsArgumentException()
    {
        // Arrange
        var address = new Address("PMR", "Tiraspol");
        var startDate = DateTime.Now.AddDays(1);
        var endDate = DateTime.Now.AddDays(2);

        // Act
        void Act() => _ = new WorkExperience("Dev", "ООО БратЛэнд", address, "Описание", startDate, endDate);

        // Assert
        Assert.Throws<ArgumentException>(Act);
    }

    [Fact]
    public void WorkExperience_EndDateBeforeStartDate_ThrowsArgumentException()
    {
        // Arrange
        var address = new Address("PMR", "Tiraspol");
        var startDate = new DateTime(2024, 01, 01);
        var endDate = new DateTime(2023, 01, 01);

        // Act
        void Act() => _ = new WorkExperience("Dev", "ООО БратЛэнд", address, "Описание", startDate, endDate);

        // Assert
        Assert.Throws<ArgumentException>(Act);
    }

    [Fact]
    public void WorkExperience_PositionTooLong_ThrowsArgumentException()
    {
        // Arrange
        var address = new Address("PMR", "Tiraspol");
        var longPosition = new string('A', 251);

        // Act
        void Act() => _ = new WorkExperience(longPosition, "ООО БратЛэнд", address, "Описание",
            new DateTime(2020, 01, 01), new DateTime(2021, 01, 01));

        // Assert
        Assert.Throws<ArgumentException>(Act);
    }

    [Fact]
    public void WorkExperience_OrganizationTooLong_ThrowsArgumentException()
    {
        // Arrange
        var address = new Address("PMR", "Tiraspol");
        var longOrg = new string('B', 251);

        // Act
        void Act() => _ = new WorkExperience("Dev", longOrg, address, "Описание",
            new DateTime(2020, 01, 01), new DateTime(2021, 01, 01)); 

        // Assert
        Assert.Throws<ArgumentException>(Act);
    }

    [Fact]
    public void EmailWithoutAtSymbol_ThrowsArgumentException()
    {
        // Arrange
        var invalidEmail = "invalidemail.com";

        // Act
        void Act() => _ = new Email(invalidEmail); 

        // Assert
        Assert.Throws<ArgumentException>(Act);
    }

    [Fact]
    public void EmailTooLong_ThrowsArgumentException()
    {
        // Arrange
        var longEmail = new string('a', 256) + "@test.com";

        // Act
        void Act() => _ = new Email(longEmail); 

        // Assert
        Assert.Throws<ArgumentException>(Act);
    }

    [Fact]
    public void PhoneInvalidNumber_ThrowsArgumentException()
    {
        // Arrange
        var invalidPhone = "12345678";

        // Act
        void Act() => _ = new Phone(invalidPhone); 

        // Assert
        Assert.Throws<ArgumentException>(Act);
    }

    [Fact]
    public void PhoneWrongLength_ThrowsArgumentException()
    {
        // Arrange
        var shortPhone = "778123";

        // Act
        void Act() => _ = new Phone(shortPhone); 

        // Assert
        Assert.Throws<ArgumentException>(Act);
    }

    [Fact]
    public void PhoneNonDigit_ThrowsArgumentException()
    {
        // Arrange
        var phoneWithLetters = "77AB5678";

        // Act
        void Act() => _ = new Phone(phoneWithLetters); 

        // Assert
        Assert.Throws<ArgumentException>(Act);
    }

    [Fact]
    public void AddressCountryTooLong_ThrowsArgumentException()
    {
        // Arrange
        var longCountry = new string('A', 251);

        // Act
        void Act() => _ = new Address(longCountry, "Tiraspol"); 

        // Assert
        Assert.Throws<ArgumentException>(Act);
    }

    [Fact]
    public void AddressCityTooLong_ThrowsArgumentException()
    {
        // Arrange
        var longCity = new string('B', 251);

        // Act
        void Act() => _ = new Address("PMR", longCity); 

        // Assert
        Assert.Throws<ArgumentException>(Act);
    }

    [Fact]
    public void PersonNameEmptyFirstName_ThrowsArgumentException()
    {
        // Arrange
        var emptyFirstName = "";

        // Act
        void Act() => _ = new PersonName(emptyFirstName, "Middle", "Last"); 

        // Assert
        Assert.Throws<ArgumentException>(Act);
    }

    [Fact]
    public void PersonNameTooShort_ThrowsArgumentException()
    {
        // Arrange
        var tooShortFirstName = "A";
        var tooShortMiddleName = "B";
        var tooShortLastName = "C";

        // Act
        void Act() => _ = new PersonName(tooShortFirstName, tooShortMiddleName, tooShortLastName); 

        // Assert
        Assert.Throws<ArgumentException>(Act);
    }

    [Fact]
    public void PersonNameTooLong_ThrowsArgumentException()
    {
        // Arrange
        var longName = new string('A', 61);

        // Act
        void Act() => _ = new PersonName(longName, "Middle", "Last"); 

        // Assert
        Assert.Throws<ArgumentException>(Act);
    }

    [Fact]
    public void PersonNameInvalidCharacters_ThrowsArgumentException()
    {
        // Arrange
        var invalidFirstName = "J0hn";

        // Act
        void Act() => _ = new PersonName(invalidFirstName, "Middle", "Last"); 

        // Assert
        Assert.Throws<ArgumentException>(Act);
    }
}
