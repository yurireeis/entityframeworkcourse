using System;

namespace ModelWithCodeFirstWorkflow
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PlutoContext context = new PlutoContext())
            {
                context.Users.Add(new User() {
                  Name = "Yuri Reis",
                  Email = "yuri@meuemail.com",
                  UserName = "yuri@meuemail.com",
                  Displayname = "Yuri"
                });
                context.SaveChanges();
            }
        }
    }
}
