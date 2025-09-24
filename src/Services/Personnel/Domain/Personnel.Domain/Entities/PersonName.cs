using Ardalis.GuardClauses;
using Personnel.Domain.Validation;

namespace Personnel.Domain.Entities
{
    /// <summary>
    /// Представляет имя пользователя, включая имя, отчество и фамилию.
    /// </summary>
    public class PersonName
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Отчество пользователя.
        /// </summary>
        public string MiddleName { get; private set; }

        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Создаёт новый экземпляр <see cref="PersonName"/>.
        /// </summary>
        /// <param name="firstName">Имя пользователя. Должно содержать только буквы, длина от 2 до 60 символов.</param>
        /// <param name="middleName">Отчество пользователя. Должно содержать только буквы, длина от 2 до 60 символов.</param>
        /// <param name="lastName">Фамилия пользователя. Должна содержать только буквы, длина от 2 до 60 символов.</param>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если любое из значений пустое, не состоит только из букв, или длина не соответствует диапазону 2–60 символов.
        /// </exception>
        public PersonName(string firstName, string middleName, string lastName)
        {
            Guard.Against.Null(firstName, nameof(firstName));
            Guard.Against.Null(middleName, nameof(middleName));
            Guard.Against.Null(lastName, nameof(lastName));
            
            FirstName = DomainValidator.ValidatePersonName(firstName, nameof(FirstName));
            MiddleName = DomainValidator.ValidatePersonName(middleName, nameof(MiddleName));
            LastName = DomainValidator.ValidatePersonName(lastName, nameof(LastName));
        }
        
    }
}
