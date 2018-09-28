namespace QueryingDataUsingLINQ.Models
{
    public class RolePermission
    {
        public string RoleKey { get; set; }
        public string PermissionKey { get; set; }
        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}
