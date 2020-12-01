using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;


namespace DapperInClass
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Configuration
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            #endregion

            IDbConnection conn = new MySqlConnection(connString);
            DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);
            //Exercise 2 portion:
            DapperProductRepository repo2 = new DapperProductRepository(conn);

            Console.WriteLine("Hello user, here are the current departments:");
            var depos = repo.GetAllDepartments();
            {
                foreach (var depo in depos)
                {
                    Console.WriteLine($"Id: {depo.DepartmentID} Name: {depo.Name}");
                }
            }
            Console.WriteLine("Please press enter . . .");
            Console.ReadLine();
            

            Console.WriteLine("Do you want to add a department???");
            string userResponse = Console.ReadLine();

            if (userResponse.ToLower() == "yes")
            {
                Console.WriteLine("What is the name of your new Department??");
                userResponse = Console.ReadLine();

                repo.InsertDepartment(userResponse);
                Print(repo.GetAllDepartments());
            }


            Console.WriteLine("Type a new Product name");
            var newProduct = Console.ReadLine();
            Console.WriteLine("What is the price?");
            var newPrice = Console.ReadLine();
            Console.WriteLine("Give it a category ID");
            var newCategoryID = Console.ReadLine();
            repo2.CreateProduct(newProduct, double.Parse(newPrice), int.Parse(newCategoryID));

            Console.WriteLine("Have a great day.");

        }

        private static void Print(IEnumerable<Department> depos)
        {
            foreach (var depo in depos)
            {
                Console.WriteLine($"Id: {depo.DepartmentID} Name: {depo.Name}");
            }
        }

        private static void Print(IEnumerable<Product> depos)
        {
            foreach (var depo in depos)
            {
                Console.WriteLine($"Id: {depo.ProductID} Name: {depo.Name}");
            }
        }
    }
}
