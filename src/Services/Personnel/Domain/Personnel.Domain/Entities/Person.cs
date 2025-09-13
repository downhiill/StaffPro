using Personnel.Domain.Entities.PersonalData;

namespace Personnel.Domain.Entities
{
    /// <summary>
    /// Представляет пользователя с личными данными и опытом работы.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Уникальный идентификатор пользователя.
        /// </summary>
        public Guid UserId { get; private set; } = Guid.NewGuid();

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public PersonName Name { get; private set; }

        /// <summary>
        /// Пол пользователя.
        /// </summary>
        public Gender Gender { get; private set; }

        /// <summary>
        /// Электронная почта пользователя.
        /// </summary>
        public Email Email { get; private set; }

        /// <summary>
        /// Телефон пользователя.
        /// </summary>
        public Phone Phone { get; private set; }

        /// <summary>
        /// Дата рождения пользователя.
        /// </summary>
        public DateTime DateOfBirth { get; private set; }

        /// <summary>
        /// Ссылка на аватар пользователя.
        /// </summary>
        public string? AvatarUrl { get; private set; }

        /// <summary>
        /// Описание пользователя.
        /// </summary>
        public string? Description { get; private set; }

        private readonly List<WorkExperience> _workExperiences = new();

        /// <summary>
        /// Коллекция опыта работы пользователя.
        /// </summary>
        public IReadOnlyCollection<WorkExperience> WorkExperiences => _workExperiences.AsReadOnly();

        /// <summary>
        /// Создаёт нового пользователя с заданными параметрами.
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        /// <param name="gender">Пол пользователя.</param>
        /// <param name="email">Электронная почта.</param>
        /// <param name="phone">Телефон.</param>
        /// <param name="dateOfBirth">Дата рождения.</param>
        /// <param name="avatarUrl">Ссылка на аватар.</param>
        /// <param name="description">Описание пользователя.</param>
        public Person(PersonName name, Gender gender, Email email, Phone phone, DateTime dateOfBirth, string avatarUrl, string description)
        {
            Name = name;
            Gender = gender;
            Email = email;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            AvatarUrl = avatarUrl;
            Description = description;
        }

        /// <summary>
        /// Устанавливает новое имя пользователя.
        /// </summary>
        /// <param name="newName">Новое имя пользователя.</param>
        public void SetPersonName(PersonName newName)
        {
            Name = newName;
        }

        /// <summary>
        /// Устанавливает новую электронную почту пользователя.
        /// </summary>
        /// <param name="newEmail">Новая электронная почта.</param>
        public void SetEmail(Email newEmail)
        {
            Email = newEmail;
        }

        /// <summary>
        /// Устанавливает новый телефон пользователя.
        /// </summary>
        /// <param name="newPhone">Новый телефон.</param>
        public void SetPhone(Phone newPhone)
        {
            Phone = newPhone;
        }

        /// <summary>
        /// Устанавливает новую дату рождения пользователя.
        /// </summary>
        /// <param name="dateOfBirth">Дата рождения.</param>
        public void SetDateOfBirth(DateTime dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
        }

        /// <summary>
        /// Устанавливает ссылку на аватар пользователя.
        /// </summary>
        /// <param name="avatarUrl">Ссылка на изображение .png или .jpg.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если формат изображения неверный.</exception>
        public void SetAvatar(string avatarUrl)
        {
            if (!avatarUrl.EndsWith(".png") && !avatarUrl.EndsWith(".jpg"))
                throw new ArgumentException("Изображение должно быть .png или .jpg");

            AvatarUrl = avatarUrl;
        }

        /// <summary>
        /// Устанавливает новый пол пользователя.
        /// </summary>
        /// <param name="newGender">Новый пол.</param>
        public void SetGender(Gender newGender)
        {
            Gender = newGender;
        }

        /// <summary>
        /// Возвращает все записи опыта работы пользователя.
        /// </summary>
        /// <returns>Коллекция опыта работы.</returns>
        public IEnumerable<WorkExperience> GetAllWorkExperiences()
        {
            return _workExperiences;
        }

        /// <summary>
        /// Добавляет новый опыт работы или обновляет существующий.
        /// </summary>
        /// <param name="experience">Экземпляр опыта работы.</param>
        public void AddOrUpdateWorkExperience(WorkExperience experience)
        {
            var existing = _workExperiences.FirstOrDefault(w => w.WorkExperienceId == experience.WorkExperienceId);

            if (existing != null)
            {
                existing.SetPosition(experience.Position);
                existing.SetOrganization(experience.Organization);
                existing.SetAddress(experience.Address);
                existing.SetDates(experience.StartDate, experience.EndDate);
                existing.SetDescription(experience.Description);
            }
            else
            {
                _workExperiences.Add(experience);
            }
        }

        /// <summary>
        /// Удаляет опыт работы по идентификатору.
        /// </summary>
        /// <param name="workExperienceId">Идентификатор опыта работы.</param>
        public void RemoveWorkExperience(Guid workExperienceId)
        {
            var existing = _workExperiences.FirstOrDefault(w => w.WorkExperienceId == workExperienceId);
            if (existing != null)
                _workExperiences.Remove(existing);
        }
    }
}
