using System;
using RepositoryPattern.Core.Repositories;

namespace RepositoryPattern.Core
{
    public interface IUnitOfWork : IDisposable
    {
         IUserRepository Users { get; }
         IUserPermissionRepository UserPermission { get; }
         int Complete();
    }
}
