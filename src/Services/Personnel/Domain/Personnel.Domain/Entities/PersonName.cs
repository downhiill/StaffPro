using Ardalis.GuardClauses;

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
            
            FirstName = Validate(firstName, nameof(FirstName));
            MiddleName = Validate(middleName, nameof(MiddleName));
            LastName = Validate(lastName, nameof(LastName));
        }
        
        private string Validate(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{fieldName} не может быть пустым");

            if (value.Length < 2 | value.Length > 60)
                throw new ArgumentException($"{fieldName} должно содержать от 2 до 60 символов");

            if (!value.All(char.IsLetter))
                throw new ArgumentException($"{fieldName} может содержать только буквы");

            return value;
        }
    }
}
