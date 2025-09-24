using Personnel.Domain.Validation;

namespace Personnel.Domain.Entities.PersonalData
{
    /// <summary>
    /// Представляет телефонный номер ПМР.
    /// </summary>
    public class Phone
    {
        /// <summary>
        /// Значение телефонного номера.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Создаёт новый экземпляр <see cref="Phone"/> с указанным номером.
        /// </summary>
        /// <param name="value">Телефонный номер. Должен начинаться с "77" или "777", состоять из 8 цифр.</param>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если номер не начинается с "77" или "777", содержит не 8 цифр, или содержит недопустимые символы.
        /// </exception>
        public Phone(string value)
        {
            Value = DomainValidator.ValidatePhone(value);
        }
    }
}