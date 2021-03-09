using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductNameAlreadyExists = "There is such a product name.";
        public static string NameInvalid = "Name is NOT invalid";
        public static string ProductCountOfCategoryError = "There must be no more than 15 products";
        public static string CategoryLimitExceded = "Category Limit exceded so New Product Added process NOT working!";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "PasswordError";
        public static string UserAlreadyExists = "UserAlreadyExists";
        public static string UserRegistered = "SuccessUserRegistered";
        public static string AccessTokenCreated = "Access token created ";
        public static string AuthorizationDenied = "AuthorizationDenied";
        public static string SuccessfullLogin = "SuccessfullLogin";
    }
}
