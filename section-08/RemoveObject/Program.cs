using System;
using System.Linq;
using RemoveObject.context;
using RemoveObject.Models;
using Microsoft.EntityFrameworkCore;

namespace RemoveObject
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TestContext())
            {
                // single remotion
                // var user = context.User.Find(1);
                // remove with eager loading
                var role = context.Role.Include(r => r.RolePermissions).Single(r => r.Id == 2);
                context.RolePermission.RemoveRange(role.RolePermissions);
                context.SaveChanges();
            }
        }
    }
}
