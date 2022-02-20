using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entites.Concrete;

namespace Business.Constants
{
    public class AuthContants
    {
        public static string AuthorizationDenied = "Yetki yok.";
        public static string UserRegisterIsSuccess = "Başarıyla kayıt oldunuz.";
        public static string UserAlreadyExists = "Bu kullanıcı zaten kayıtlı.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Girdiğiniz şifre hatalı.";
        public static string SuccessfulLogin = "Giriş başarı ile tamamlandı.";
        public static string AccessTokenCreated = "Giriş başarılı";
        public static string VerifyYourEmailAddress = "Lütfen mail adresinizi onaylayın";
    }
}
