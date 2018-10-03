using EagerLoading.Core.Domain;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Core.Repositories;

namespace RepositoryPattern.Persistence.Repositories
{
  public class UserPermissionRepository : Repository<UserPermission>, IUserPermissionRepository
  {
    public UserPermissionRepository(DbContext context) : base(context) { }
  }
}
