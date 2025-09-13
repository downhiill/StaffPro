namespace Personnel.Domain.Entities
{
    /// <summary>
    /// Пол пользователя.
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Мужской.
        /// </summary>
        Male = 0,

        /// <summary>
        /// Женский.
        /// </summary>
        Female = 1,

        /// <summary>
        /// Специальное значение (например, тестовое или нестандартное).
        /// </summary>
        Brat = 777
    }
}