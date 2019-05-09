using Build_IT_DataAccess;
using Build_IT_DataAccess.DeadLoads;
using Build_IT_DataAccess.DeadLoads.Repositories;
using Build_IT_DataAccess.ScriptInterpreter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContextOptions = new DbContextOptionsBuilder<DeadLoadsDbContext>()
                .UseSqlServer("server=localhost; database=Build_IT_DeadLoads; Integrated Security=SSPI;");

            var deadLoadsContext = new DeadLoadsDbContext(dbContextOptions.Options);

            var unitOfWork = new DeadLoadsUnitOfWork(deadLoadsContext,
                new CategoryRepository(deadLoadsContext),
                new SubcategoryRepository(deadLoadsContext),
                new MaterialRepository(deadLoadsContext));
            //var materialRepo = unitOfWork.Materials;

            foreach (var category in unitOfWork.Categories.GetAllAsync().Result)
            {
                Console.WriteLine(category.Name);

                foreach (var subcategory in unitOfWork.Subcategories
                    .GetAllSubcategoriesForCategoryAsync(category.Id).Result)
                {
                    Console.WriteLine("  " + subcategory.Name);

                    foreach (var material in unitOfWork.Materials
                        .GetAllMaterialsForSubcategoryAsync(subcategory.Id).Result)
                    {
                        Console.WriteLine("    " + material.Name);
                    }
                }
            }


            var categories = deadLoadsContext.Categories;
            foreach (var category in categories)
            {
                Console.WriteLine(category.Name);

                foreach (var subcategory in deadLoadsContext.Subcategories
                    .Where(s => s.CategoryId== category.Id))
                {
                    Console.WriteLine("  " + subcategory.Name);

                    foreach (var material in deadLoadsContext.Materials
                    .Where(s => s.SubcategoryId == subcategory.Id))
                    {
                        Console.WriteLine("    " + material.Name);
                    }
                }
            }

            deadLoadsContext.Dispose();
            Console.ReadLine();
        }
    }
}
