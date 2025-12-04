namespace UserApi.Entities
{
    /// <summary>
    /// Пользователь системы.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя пользователя (логин).
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// пароль пользователя.
        /// </summary>
        public string Password { get; set; } = null!;

        /// <summary>
        /// Роль пользователя.
        /// </summary>
        public string Role { get; set; } = "User";
    }
}
