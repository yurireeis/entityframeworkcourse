using System.Collections.Generic;
using System.Linq;
using EagerLoading.Core.Domain;
using EagerLoading.Persistence;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Core.Repositories;

namespace RepositoryPattern.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public TestContext TestContext { get { return Context as TestContext; } }
        public UserRepository(TestContext context) : base(context) { }
        public User GetUser(int id) => TestContext.User.SingleOrDefault(u => u.Id == id);

        public ICollection<User> GetUsers(int index = 0, int offset = 10) => TestContext.User.OrderBy(u => u.Name)
            .Skip(index).Take(offset).ToList();

        public ICollection<User> GetUsersWithRoles(int index = 0, int offset = 10) => TestContext.User.Include(u => u.Role)
            .OrderBy(u => u.Name).Skip(index).Take(offset).ToList();

        public ICollection<User> GetUsersWithPermissions(int index = 0, int offset = 10)=> TestContext.User.Include(u => u.UserPermissions)
                .OrderBy(u => u.Name).Skip(index).Take(offset).ToList();
     }
}
