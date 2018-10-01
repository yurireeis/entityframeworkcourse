using System;
using QueryingDataUsingLINQ.Contexts;
using System.Linq;
using QueryingDataUsingLINQ.Models;

namespace QueryingDataUsingLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // Language INtegrated Query (LINQ)
            // query sintax and integrated query (two ways)
            // LINQ is an api to query any data store!
            // LINQ is not desired to complex queries (use stored procedures for that)

            using (TestContext context = new TestContext())
            {
                // LINQ Synthax
                var users = from user in context.User 
                    where user.Name.Contains("reis")
                    orderby user.Name
                    select user;
                
                foreach (var user in users)
                {
                    Console.WriteLine($"User: {user.Name}");
                }

                // Extension Methods (more powerful)
                var users1 = context.User.Where(u => u.Name.Contains("0"))
                    .OrderBy(u => u.Name);

                foreach (var user in users1)
                {
                    Console.WriteLine($"User with extension methods: {user.Name}");
                }

                // filtering (by default users and contains Yuri)
                var users2 = from u in context.User
                    where u.RoleId == 1 && u.Name.Contains("Yuri")
                    orderby u.Name descending
                    select u;
                
                foreach (var user in users2)
                {
                    Console.WriteLine($"Admin users: {user.Name}");
                }

                // Projection (create a new object to send an smaller object - optimization)
                    var users3 = from u in context.User
                    where u.RoleId == 1
                    orderby u.Name descending
                    select new { Name = u.Name, Email = u.Email };
                
                foreach (var user in users3)
                {
                    Console.WriteLine($"Projection users: {user.Name}");
                }

                // grouping (g will be the groups by implemented criteria)
                var groups = from u in context.User
                    group u by u.RoleId into g
                    select g;

                foreach (var group in groups)
                {
                    Console.WriteLine($"Group: {group.Key}, Results: {group.Count()}");

                    foreach (var user in group)
                    {
                        Console.WriteLine($"\t {user.Name}");
                    }
                }

                // when you have navigation properties, you don't need to make inner joins
                var users5 = from user in context.User
                    select new { Name = user.Name, Role = user.Role.Name };
                
                Console.WriteLine("Using navigation property and projection: ");
                foreach (var user in users5)
                {
                    Console.WriteLine($"\tName: {user.Name}, Role: {user.Role}");
                }

                // p.s.: only use inner join with entities that doesn't have navigation property
                // the code above is only for testing purpose (join)
                var users6 = from user in context.User
                    join r in context.Role on user.RoleId equals r.Id
                    select new { Name = user.Name, Role = r.Name };
                
                Console.WriteLine("Using join and projection: ");
                foreach (var user in users6)
                {
                    Console.WriteLine($"\tName: {user.Name}, Role: {user.Role}");
                }

                // making a join with Linq Extensions
                var users7 = context.User.Join(
                    context.Role, u => u.RoleId,
                    r => r.Id, (user, role) => new {
                        Name = user.Name,
                        RoleName = role.Name
                });

                foreach (var user in users7)
                {
                    Console.WriteLine($"Name: {user.Name}, Role: {user.RoleName}");
                }

                // making group join with Linq Extensions (CrossJoin)
                var users8 = context.User.GroupJoin(context.User, 
                    r => r.Id, u => u.RoleId,
                    (usrs, rls) => new {
                        Name = usrs.Name,
                        Role = rls.Count()
                });

                foreach (var user in users8)
                {
                    Console.WriteLine($"Name: {user.Name}, Number of Roles: {user.Role}");
                }

                Console.WriteLine("----------");

                // partitioning (page of records)
                var users9 = context.User.Skip(2).Take(4).OrderBy(u => u.Name);
                foreach (var user in users9)
                {
                    Console.WriteLine($"Name: {user.Name}");
                }

                // select first result
                var user1 = context.User.First();
                Console.WriteLine($"First user: {user1.Name}, UserID: {user1.Id}");

                // first or default returns the first result by the predicate (condition)
                var firstAdminUser = context.User.FirstOrDefault(u => u.RoleId == 2);
                Console.WriteLine($"First admin user in the database is: {firstAdminUser.Name}");

                // single done the same job as first, but needs predicate or will raise an exception
                var user2 = context.User.First(u => u.Id == 1);
                Console.WriteLine($"First user: {user1.Name}, UserID: {user1.Id}");

                // quantifying
                // validate conditions
                var isAllAdminUsers = context.User.All(u => u.RoleId == 2);
                Console.WriteLine($"Has admin users? {isAllAdminUsers}");

                var hasAnyAdminUsers = context.User.Any(u => u.RoleId == 2);
                Console.WriteLine($"Has any admin users? {hasAnyAdminUsers}");

                // agregating
                var count = context.User.Where(u => u.RoleId == 2).Count();
                var max = context.User.Max();
                var min = context.User.Min();
                var avg = context.User.Average(u => u.RoleId);
            }
        }
    }
}
