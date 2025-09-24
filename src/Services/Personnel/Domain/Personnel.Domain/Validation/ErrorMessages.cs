namespace Personnel.Domain.Validation;

public static class ErrorMessages
{
    public const string CannotBeEmpty = "{0} не может быть пустым";
    public const string LengthFromTo = "{0} должно содержать от {1} до {2} символов";
    public const string LengthTo = "{0} не может быть больше 250 символов";
    public const string LengthEmailTo = "Email не может быть больше 255 символов";
    public const string EmailContains = "Email должен содержать '@'";
    public const string CanBeOnlyLetters = "{0} может содержать только буквы";
    public const string FormatImage = "Изображение должно быть .png или .jpg";
    public const string RangeStartDate = "Дата начала работы не может быть в будущем";
    public const string RangeEndDate = "Дата окончания работы не может быть раньше даты начала";
    public const string PermittedPhone = "Разрешены только номера ПМР";
    public const string StandardPhoneNumber = "Номер должен быть формата 77хххххх или 777ххххх";
    public const string HaveOnlyNumbers = "Номер должен состоять из цифр";

}