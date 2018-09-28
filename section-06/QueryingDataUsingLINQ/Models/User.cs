using System.Collections.Generic;

namespace QueryingDataUsingLINQ.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string RoleKey { get; set; }
        public ICollection<UserPermission> UserPermissions { get; set; }
        public Role Role { get; set; }
    }
}
