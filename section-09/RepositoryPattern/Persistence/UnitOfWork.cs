using EagerLoading.Persistence;
using RepositoryPattern.Core;
using RepositoryPattern.Core.Repositories;
using RepositoryPattern.Persistence.Repositories;

namespace RepositoryPattern.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestContext _context;
        public IUserRepository Users { get; private set; }
        public IUserPermissionRepository UserPermission { get; set; }
        public UnitOfWork(TestContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            UserPermission = new UserPermissionRepository(_context);
        }


        public int Complete() => _context.SaveChanges();

        public void Dispose() => _context.Dispose();
    }
}
