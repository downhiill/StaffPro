namespace Personnel.Domain.Validation;

public static class DomainValidator
{
    public static string ValidateAddress(string value, string fieldName)
    {
        if (value.Length > 250)
            throw new ArgumentException(string.Format(ErrorMessages.LengthTo, fieldName));
        
        return value;
    }
    
    public static string ValidateEmail(string value)
    {
        if (value.Length > 255)
            throw new ArgumentException(ErrorMessages.LengthEmailTo);
        
        if (!value.Contains('@'))
            throw new ArgumentException(ErrorMessages.EmailContains);
        
        return value;
    }

    public static string ValidatePhone(string value)
    {
        if (!value.StartsWith("77") && !value.StartsWith("777"))
            throw new ArgumentException(ErrorMessages.PermittedPhone);
        if (value.Length != 8)
            throw new ArgumentException(ErrorMessages.StandardPhoneNumber);
        if (!value.All(char.IsDigit))
            throw new ArgumentException(ErrorMessages.HaveOnlyNumbers);
        
        return value;
    }

    public static string ValidateWorkExperience(string value, string fieldName)
    {
        if (value.Length > 250)
            throw new ArgumentException(string.Format(ErrorMessages.LengthTo, fieldName));
        
        return value;
    }

    public static (DateTime startDate, DateTime endDate) ValidateWorkExperienceDate(DateTime startDate, DateTime endDate)
    {
        if (startDate > DateTime.Now)
            throw new ArgumentException(ErrorMessages.RangeStartDate);
        if (endDate < startDate)
            throw new ArgumentException(ErrorMessages.RangeEndDate);
        return (startDate, endDate);
    }
    
    public static string ValidateFormatAvatar(string value)
    {
        if (!value.EndsWith(".png") && !value.EndsWith(".jpg"))
            throw new ArgumentException(ErrorMessages.FormatImage);

        return value;
    }

    public static string ValidatePersonName(string value, string fieldName)
    {
        
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(string.Format(ErrorMessages.CannotBeEmpty, fieldName));

        if (value.Length < 2 | value.Length > 60)
            throw new ArgumentException(string.Format(ErrorMessages.LengthFromTo, fieldName, 2, 60));

        if (!value.All(char.IsLetter))
            throw new ArgumentException(string.Format(ErrorMessages.CanBeOnlyLetters, fieldName));
        
        return value;
       
    }
}