using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constant
{
    public static class Messages
    {
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandUpdated = "Marka Güncellendi";
        public static string ColorAdded = "Renk Eklendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string CarAdded = "Araba Eklendi";
        public static string CarDeleted = "Araba Silindi";
        public static string CarUpdated = "Araba Güncellendi";
        public static string AuthorizationDenied = "yetkiniz yok";
        public static string Registered = "Kullanıcı kayıt oldu.";
        public static string IncorrectPassword = "Parola hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string AccessTokenCreated = "Access Token Oluşturuldu";
        public static string CreditCardAdded = "Kredi Kartı Eklendi";
        public static string CreditCardDeleted = "Kredi Kartı Silindi";
        public static string CreditCardUpdated = "Kredi Kartınız Güncellendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerAdded = "Müşteri Eklendi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string FindexAdded = "Findex eklendi";
        public static string FindexDeleted = "Findex Silindi";
        public static string FindexUpdated = "Findix Güncellendi";
        public static string RentalDelivered = "Araç Teslim Edildi";
        public static string RentalDeleted = "Arac Bilgisi Silindi.";
        public static string RentalAdded = "Araç kiralandı";
        public static string RentalGetAllSuccess = "Tüm araçlar listelendi";
        public static string RentalUpdated = "Araç bilgisi güncellendi";
        public static string RentalCheckIsCarReturnError = "araç kullanımda";
        public static string NoRecording = "Kayıt Bulanamadı";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserAdded = "Kullanıcı Eklendi";
    }
}
