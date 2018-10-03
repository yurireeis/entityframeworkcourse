using System.Collections.Generic;

namespace EagerLoading.Core.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public IEnumerable<UserPermission> UserPermissions { get; set; }
        public Role Role { get; set; }
    }
}
