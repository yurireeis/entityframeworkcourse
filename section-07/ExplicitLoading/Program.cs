using System;
using System.Linq;
using ExplicitLoading.context;
using ExplicitLoading.Models;
using Microsoft.EntityFrameworkCore;

namespace ExplicitLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TestContext())
            {
                // explicit loading make separate queries and multiple round-trips, instead of eager loading, that uses JOINs and make a one round trip
                // fits better when you don't have a massive amount of data, and wants to make non-AOT loading
                var user = context.User.Single(u => u.Id == 1);

                // MSDN way to make explicit loading. Don't use because this works only with single entries
                // context.Entry(users).Collection(u => u.UserPermissions).Load();

                // another way to make an explicit load (for role and for permissions)
                context.Role.Where(r => r.Id == user.RoleId).Load();
            }
        }
    }
}
