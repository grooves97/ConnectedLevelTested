﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectedLevelTested.DataAcces;
using ConnectedLevelTested.Models;

namespace ConnectedLevelTested.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new UsersTableDataService();

            service.Add(new User
            {
                Login = "Admin",
                Password = "root"
            });

            service.Add(new User
            {
                Login = "User",
                Password = "123"
            });

            foreach (var user in service.GetAll())
            {
                Console.WriteLine($"{user.Id}, {user.Login}, {user.Password}");
            }

            Console.ReadLine();
        }
    }
}
