using Ardalis.GuardClauses;
using Personnel.Domain.Validation;

namespace Personnel.Domain.Entities.PersonalData
{
    /// <summary>
    /// Представляет опыт работы пользователя.
    /// </summary>
    public class WorkExperience
    {
        /// <summary>
        /// Уникальный идентификатор опыта работы.
        /// </summary>
        public Guid WorkExperienceId { get; private set; } = Guid.NewGuid();

        /// <summary>
        /// Должность.
        /// </summary>
        public string Position { get; private set; }

        /// <summary>
        /// Организация.
        /// </summary>
        public string Organization { get; private set; }

        /// <summary>
        /// Адрес организации.
        /// </summary>
        public Address Address { get; private set; }

        /// <summary>
        /// Описание опыта работы.
        /// </summary>
        public string? Description { get; private set; }

        /// <summary>
        /// Дата начала работы.
        /// </summary>
        public DateTime StartDate { get; private set; }

        /// <summary>
        /// Дата окончания работы.
        /// </summary>
        public DateTime EndDate { get; private set; }

        /// <summary>
        /// Создаёт новый экземпляр <see cref="WorkExperience"/>.
        /// </summary>
        /// <param name="position">Должность. Не может быть длиннее 250 символов.</param>
        /// <param name="organization">Организация. Не может быть длиннее 250 символов.</param>
        /// <param name="address">Адрес организации.</param>
        /// <param name="description">Описание опыта работы.</param>
        /// <param name="startDate">Дата начала работы. Не может быть в будущем.</param>
        /// <param name="endDate">Дата окончания работы. Не может быть раньше <paramref name="startDate"/>.</param>
        /// <exception cref="ArgumentException">
        /// Выбрасывается, если <paramref name="position"/> или <paramref name="organization"/> длиннее 250 символов,
        /// или если даты заданы некорректно.
        /// </exception>
        public WorkExperience(string position, string organization, Address address, string description,
            DateTime startDate, DateTime endDate)
        {
            Guard.Against.Null(position, nameof(position));
            Guard.Against.Null(organization, nameof(organization));
            Guard.Against.Null(address, nameof(address));

            Position = DomainValidator.ValidateWorkExperience(position, nameof(position));
            Organization = DomainValidator.ValidateWorkExperience(organization, nameof(organization));
            Address = address;
            Description = description;
            SetDates(startDate, endDate);
        }

        /// <summary>
        /// Устанавливает должность.
        /// </summary>
        /// <param name="position">Должность. Не может быть длиннее 250 символов.</param>
        public void SetPosition(string position)
        {
            Guard.Against.Null(position, nameof(position));
            Position = DomainValidator.ValidateWorkExperience(position, nameof(position));
        }

        /// <summary>
        /// Устанавливает организацию.
        /// </summary>
        /// <param name="organization">Организация. Не может быть длиннее 250 символов.</param>
        public void SetOrganization(string organization)
        {
            Guard.Against.Null(organization, nameof(organization));
            Organization = DomainValidator.ValidateWorkExperience(organization, nameof(organization));
        }

        /// <summary>
        /// Устанавливает адрес организации.
        /// </summary>
        /// <param name="address">Адрес организации.</param>
        public void SetAddress(Address address)
        {
            Guard.Against.Null(address, nameof(address));
            Address = address;
        }

        /// <summary>
        /// Устанавливает описание опыта работы.
        /// </summary>
        /// <param name="description">Описание опыта работы.</param>
        public void SetDescription(string? description) => Description = description;

        /// <summary>
        /// Устанавливает даты начала и окончания работы.
        /// </summary>
        /// <param name="startDate">Дата начала работы. Не может быть в будущем.</param>
        /// <param name="endDate">Дата окончания работы. Не может быть раньше <paramref name="startDate"/>.</param>
        /// <exception cref="ArgumentException">Выбрасывается при некорректных датах.</exception>
        public void SetDates(DateTime startDate, DateTime endDate)
        {
            (StartDate, EndDate) = DomainValidator.ValidateWorkExperienceDate(startDate, endDate);
        }
    }
}