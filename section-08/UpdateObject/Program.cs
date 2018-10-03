using System;
using System.Linq;
using UpdateObject.context;
using UpdateObject.Models;
using Microsoft.EntityFrameworkCore;

namespace UpdateObject
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TestContext())
            {
                // to recover an object, use find method
                // find method accepts more than one value (for composite keys for example)
                // User user = context.User.FirstOrDefault(u => u.Id == 4);
                // user.Email = "naoinformado1@me.com";
                // var email = context.User.Where(u => u.Id == 4).Select(u => u.Email).First();

                var test = new User{ Id = 4, Email = "naoinformado5@me.com" };
                // context.User.Attach(test);
                context.Entry(test).Property(u => u.Email).IsModified = true;
                context.SaveChanges();
            }
        }
    }
}
