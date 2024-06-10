using Common;

namespace BackEnd.Models.Users
{
    public class UpdateUserModel
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public int RoleId { get; set; }
    }
}
