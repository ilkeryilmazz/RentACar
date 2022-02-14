using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class BrandConstants
    {
        public static string BrandAdded = "Marka başarıyla eklendi.";
        public static string BrandDeleted = "Marka başarıyla silindi.";
        public static string BrandUpdated = "Marka bilgileri başarıyla güncellendi.";

        public static string BrandNotAdded = "Marka eklenemedi.";
        public static string BrandNotDeleted = "Marka silinemedi.";
        public static string BrandNotUpdated = "Marka güncellenemedi.";

        public static string AllBrandGetted = "Tüm Marka bilgileri getirildi.";
        public static string AllBrandNotGetted = "Markaların bilgileri getirilemedi.";

        public static string BrandGettedById = "Marka getirildi";
        public static string BrandNotGettedById = "Marka getirelemedi.";

        public static string MaximumBrandLimitExceeded = "Ekleyebileceğiniz marka limiti aşıldı.";
        public static string BrandNameExists = "Bu isimde bir marka zaten mevcut.";
        public static string BrandIsHaveCarCantDeleted = "Bu markaya ait bir araç olduğu için markayı silemezsiniz";
    }
}
