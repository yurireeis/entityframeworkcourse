using System;
using System.Linq;
using AddObject.context;
using AddObject.Models;
using Microsoft.EntityFrameworkCore;

namespace AddObject
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TestContext())
            {
                User user = new User {
                  Name = "Maria Angelica",
                  Username = "mangelica@me.com",
                  Email = "mangelica@me.com",
                  // roleId is the web approach to deal with new objects creation
                  RoleId = 1
                };

                // change tracker and dbcontext sees user as a new object (it's not persisted in db yet)
                context.User.Add(user);
                context.SaveChanges();
            }
        }
    }
}
