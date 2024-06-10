using Common;

namespace BackEnd.Models.Auth
{
    public class RegisterModel
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set; }
    }
}
