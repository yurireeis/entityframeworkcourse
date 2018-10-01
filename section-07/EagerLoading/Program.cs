using System;
using System.Linq;
using EagerLoading.context;
using EagerLoading.Models;
using Microsoft.EntityFrameworkCore;

namespace EagerLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TestContext())
            {
                // eager loading to avoid cyclic sql requests per user to get roles
                var users = context.User.Include(u => u.Role);

                foreach (var user in users)
                {
                    Console.WriteLine($"User: {user.Name}, Role: {user.Role.Name}");
                }
            }
        }
    }
}
