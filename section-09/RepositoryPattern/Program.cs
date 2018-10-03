using System;
using System.Linq;
using EagerLoading.Persistence;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Persistence;

namespace EagerLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new TestContext()))
            {
                // example 1: single user query
                var singleUser = unitOfWork.Users.GetUser(2);
                Console.WriteLine($"The user is {singleUser.Name}");

                // example 2: list of users with pagination and index
                var users = unitOfWork.Users.GetUsersWithPermissions(10, 4);
                Console.WriteLine("Users:");
                foreach (var user in users) { Console.WriteLine($"ID: {user.Id} Name: {user.Name}"); }

                // example 3: remove user individual permissions
                unitOfWork.UserPermission.RemoveRange(singleUser.UserPermissions);
            }
        }
    }
}
