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
        public static string Added = "Add process OK";
        public static string Deleted = "Delete process OK";
        public static string Updated = "Update process OK";
        public static string NameInvalid = "Name is NOT invalid";
        public static string MaintenanceTime = "System is under maintenance";
        public static string Listed = "List process OK";
        public static string ProductCountOfCategoryError = "There must be no more than 15 products";
        public static string CategoryLimitExceded = "Category Limit Exceded so New Product Added process NOT working!";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";
    }
}
