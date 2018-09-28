using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAnnotations.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string Name { get; set; }

        // [Required] make required using data annotation
        public string UserName { get; set; }
        
        public string Email { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
