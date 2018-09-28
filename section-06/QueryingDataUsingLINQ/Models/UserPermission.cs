namespace QueryingDataUsingLINQ.Models
{
    public class UserPermission
    {
        public int UserId { get; set; }
        public string PermissionKey { get; set; }
        public User User { get; set; }
        public Permission Permission { get; set; }
    }
}
