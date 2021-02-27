using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // ProductTest();
            // CategoryTest();

        }

        //private static void CategoryTest()
        //{
        //    CategoryManager categoryManager = new CategoryManager(new EFCategoryDAL());
        //    var result = categoryManager.GetAll();
        //    foreach (var category in result.Data)
        //    {
        //        Console.WriteLine(category.CategoryName);
        //    }
        //}
        //private static void ProductTest()
        //{
        //    ProductManager productManager = new ProductManager(new EFProductDAL());
        //    var result = productManager.GetProductDetails();

        //    if (result.Success == true)
        //    {
        //        foreach (var product in result.Data)
        //        {
        //            Console.WriteLine(product.ProductName + "/" + product.CategoryName);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }
               
            
        //}
    }
}
