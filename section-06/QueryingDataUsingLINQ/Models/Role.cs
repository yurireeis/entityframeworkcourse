using System.Collections.Generic;

namespace QueryingDataUsingLINQ.Models
{
    public class Role
    {
        public string Key { get => _Key; set => _Key = value.ToLower(); }
        public string Name { get; set; }
        public string Description { get; set; }
        private string _Key { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
