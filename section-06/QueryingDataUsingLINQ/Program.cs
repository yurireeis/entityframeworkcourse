using System;
using QueryingDataUsingLINQ.Contexts;
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
                context.User.Add(new User() {
                    Name = "Yuri Reis",
                    Username = "yuri@email.com",
                    Email = "yuri@email.com",
                    RoleId = 1
                });

                context.SaveChanges();
            }
        }
    }
}
