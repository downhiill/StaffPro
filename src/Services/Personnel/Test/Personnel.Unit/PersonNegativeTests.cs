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
    public void SetAvatar()
    {
        var person = CreatePerson();
        
        Assert.Throws<ArgumentException>(() => person.SetAvatar("avatar.gif"));
    }
    
    [Fact]
    public void WorkExperience_StartDateInFuture()
    {
        var address = new Address("PMR", "Tiraspol");
        
        Assert.Throws<ArgumentException>(() => 
            new WorkExperience(
                "Dev",
                "ООО БратЛэнд",
                address,
                "Описание",
                DateTime.Now.AddDays(1),
                DateTime.Now.AddDays(2)
                ));
    }
    
    [Fact]
    public void WorkExperience_EndDateBeforeStartDate()
    {
        var address = new Address("PMR", "Tiraspol");
        
        Assert.Throws<ArgumentException>(() => 
            new WorkExperience(
                "Dev",
                "ООО БратЛэнд",
                address,
                "Описание",
                new DateTime(2024, 01, 01),
                new DateTime(2023, 01, 01)
            ));
    }
    
    [Fact]
    public void WorkExperience_PositionTooLong()
    {
        var address = new Address("PMR", "Tiraspol");
        var longPosition = new string('A', 251);
        
        Assert.Throws<ArgumentException>(() => 
            new WorkExperience(
                longPosition,
                "ООО БратЛэнд",
                address,
                "Описание",
                new DateTime(2020, 01, 01),
                new DateTime(2021, 01, 01)
            ));
    }
    
    [Fact]
    public void WorkExperience_OrganizationTooLong()
    {
        var address = new Address("PMR", "Tiraspol");
        var longOrg = new string('B', 251);
        
        Assert.Throws<ArgumentException>(() => 
            new WorkExperience(
                "Dev",
                longOrg,
                address,
                "Описание",
                new DateTime(2020, 01, 01),
                new DateTime(2021, 01, 01)
            ));
    }
    
    [Fact]
    public void EmailWithoutAtSymbol()
    {
        Assert.Throws<ArgumentException>(() => new Email("invalidemail.com"));
    }

    [Fact]
    public void EmailTooLong()
    {
        var longEmail = new string('a', 256) + "@test.com";
        Assert.Throws<ArgumentException>(() => new Email(longEmail));
    }

    [Fact]
    public void PhoneInvalidNumber()
    {
        // не содержит 77 или 777
        Assert.Throws<ArgumentException>(() => new Phone("12345678"));
    }

    [Fact]
    public void PhoneWrongLength()
    {
        // меньше 8 цифр
        Assert.Throws<ArgumentException>(() => new Phone("778123"));
    }

    [Fact]
    public void PhoneNonDigit()
    {
        // содержит буквы
        Assert.Throws<ArgumentException>(() => new Phone("77AB5678"));
    }

    [Fact]
    public void AddressCountryTooLong()
    {
        var longCountry = new string('A', 251);
        Assert.Throws<ArgumentException>(() => new Address(longCountry, "Tiraspol"));
    }

    [Fact]
    public void AddressCityTooLong()
    {
        var longCity = new string('B', 251);
        Assert.Throws<ArgumentException>(() => new Address("PMR", longCity));
    }

    [Fact]
    public void PersonNameEmptyFirstName()
    {
        Assert.Throws<ArgumentException>(() => new PersonName("", "Middle", "Last"));
    }

    [Fact]
    public void PersonNameTooShort()
    {
        Assert.Throws<ArgumentException>(() => new PersonName("A", "B", "C"));
    }

    [Fact]
    public void PersonNameTooLong()
    {
        var longName = new string('A', 61);
        Assert.Throws<ArgumentException>(() => new PersonName(longName, "Middle", "Last"));
    }

    [Fact]
    public void PersonNameInvalidCharacters()
    {
        Assert.Throws<ArgumentException>(() => new PersonName("J0hn", "Middle", "Last"));
    }
    
    
    
    
    
}