using System.Collections.Generic;

namespace DataAnnotations.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
