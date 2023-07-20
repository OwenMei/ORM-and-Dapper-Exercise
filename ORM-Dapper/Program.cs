using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            var repo = new DapperDepartmentRepository(conn);

            Console.WriteLine("Would you like to add a department? yes/no");
            var response = Console.ReadLine();

            if (response.ToLower() == "yes")
            {
                Console.WriteLine("Type a new Department name");
                var newDepartment = Console.ReadLine();
                repo.InsertDepartment(newDepartment);
            }

            Console.WriteLine("Would you like to remove a department? yes/no");
            response = Console.ReadLine();

            if (response.ToLower() == "yes")
            {
                Console.WriteLine("Delete an existing Department name");
                var newDepartment1 = Console.ReadLine();
                repo.DeleteDepartment(newDepartment1);
            }

            var Departments = repo.GetAllDepartments();

            foreach(var department in Departments)
            {
                Console.WriteLine(department.Name);
            }

            Console.WriteLine();
            
            var prodRepo = new DapperProductRepository(conn);

            Console.WriteLine("Would you like to update a product? yes/no");
            response = Console.ReadLine();

            if (response.ToLower() == "yes")
            {
                Console.WriteLine("What is the name of the product that will be updated?");
                var prodName = Console.ReadLine();
                Console.WriteLine("What is its new price?");
                var prodPrice = double.Parse(Console.ReadLine());
                Console.WriteLine("What is its new category ID");
                var catID = int.Parse(Console.ReadLine());
                prodRepo.UpdateProduct(prodName, prodPrice, catID);
            }

            Console.WriteLine("Would you like to add a product? yes/no");
            response = Console.ReadLine();

            if (response.ToLower() == "yes")
            {
                Console.WriteLine("What is its name?");
                var prodName = Console.ReadLine();
                Console.WriteLine("What is its price?");
                var prodPrice = double.Parse(Console.ReadLine());
                Console.WriteLine("What is its category ID");
                var catID = int.Parse(Console.ReadLine());
                prodRepo.CreateProduct(prodName, prodPrice, catID);
            }

            Console.WriteLine("Would you like to remove a product? yes/no");
            response = Console.ReadLine();

            if (response.ToLower() == "yes")
            {
                Console.WriteLine("Delete an existing product name");
                var newProduct1 = Console.ReadLine();
                prodRepo.RemoveProduct(newProduct1);
            }

            var AllProds = prodRepo.GetAllProducts();
            foreach( var prods in AllProds)
            {
                Console.WriteLine(prods.Name + prods.Price + prods.CategoryID);
            }

        }
    }
}
