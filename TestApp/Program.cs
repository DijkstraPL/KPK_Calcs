using Build_IT_DataAccess;
using Build_IT_DataAccess.DeadLoads;
using Build_IT_DataAccess.ScriptInterpreter;
using Microsoft.EntityFrameworkCore;
using System;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContextOptions = new DbContextOptionsBuilder<DeadLoadsDbContext>()
                .UseSqlServer("server=localhost; database=Build_IT_DeadLoads; Integrated Security=SSPI;");

            var categoriesContext = new DeadLoadsDbContext(dbContextOptions.Options);

            var unitOfWork = new DeadLoadsUnitOfWork(categoriesContext);
            var materialRepo = unitOfWork.Materials;

            foreach (var material in materialRepo.GetAllAsync().Result)
            {
                Console.WriteLine(material.Name);
            }


            var categories = categoriesContext.Categories;
            foreach (var category in categories)
            {
                Console.WriteLine(category.Name);

                foreach (var subcategory in category.Subcategories)
                {
                    Console.WriteLine("  " + subcategory.Name);

                    foreach (var material in subcategory.Materials)
                    {
                        Console.WriteLine("    " + material.Name);
                    }
                }
            }

            categoriesContext.Dispose();
            Console.ReadLine();
        }
    }
}
