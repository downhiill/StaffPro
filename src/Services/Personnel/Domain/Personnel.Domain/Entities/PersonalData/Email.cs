namespace Personnel.Domain.Entities.PersonalData
{
    /// <summary>
    /// Представляет электронную почту пользователя с валидацией.
    /// </summary>
    public class Email
    {
        /// <summary>
        /// Значение электронной почты.
        /// </summary>
        public string? Value { get; private set; }

        /// <summary>
        /// Создает новую электронную почту с проверкой корректности.
        /// </summary>
        /// <param name="value">Адрес электронной почты.</param>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если длина строки больше 255 символов или отсутствует символ '@'.
        /// </exception>
        public Email(string value)
        {
            if (value.Length > 255)
                throw new ArgumentException($"Email не может быть больше 255 символов");
            if (!value.Contains('@'))
                throw new ArgumentException("Email должен содержать '@'");

            Value = value;
        }
    }
}