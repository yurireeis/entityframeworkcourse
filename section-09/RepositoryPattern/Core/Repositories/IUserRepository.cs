using System.Collections.Generic;
using EagerLoading.Core.Domain;

namespace RepositoryPattern.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
         User GetUser(int id);

         ICollection<User> GetUsers(int pageIndex = 0, int pageSize = 10);

         ICollection<User> GetUsersWithRoles(int pageIndex = 0, int pageSize = 10);
         ICollection<User> GetUsersWithPermissions(int pageIndex = 0, int pageSize = 10);
    }
}
