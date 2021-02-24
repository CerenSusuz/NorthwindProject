using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductNameAlreadyExists = "There is such a product name.";
        public static string Added = "Add process OK";
        public static string Deleted = "Delete process OK";
        public static string Updated = "Update process OK";
        public static string NameInvalid = "Name is NOT invalid";
        public static string MaintenanceTime = "System is under maintenance";
        public static string Listed = "List process OK";
        public static string ProductCountOfCategoryError = "There must be no more than 15 products";
        public static string CategoryLimitExceded = "Category Limit Exceded so New Product Added process NOT working!";
    }
}
