using Ardalis.GuardClauses;

namespace Personnel.Domain.Entities.PersonalData
{
    /// <summary>
    /// Представляет адрес с указанием страны и города.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Страна.
        /// </summary>
        public string Country { get; private set; }

        /// <summary>
        /// Город.
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// Создаёт новый экземпляр <see cref="Address"/>.
        /// </summary>
        /// <param name="country">Название страны. Должно быть не длиннее 250 символов.</param>
        /// <param name="city">Название города. Должно быть не длиннее 250 символов.</param>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если <paramref name="country"/> или <paramref name="city"/> длиннее 250 символов.
        /// </exception>
        public Address(string country, string city)
        {
            Guard.Against.Null(country, nameof(country));
            Guard.Against.Null(city, nameof(city));
            
            Country = Validation(country, nameof(country));
            City = Validation(city, nameof(city));
        }
        
        private string Validation(string value, string fieldName)
        {
            if (value.Length > 250)
                throw new ArgumentException($"{fieldName} не может быть больше 250 символов", fieldName);
            return value;
        }
    }
}