using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class CarConstants
    {
        public static string CarAdded = "Araba başarıyla eklendi.";
        public static string CarDeleted = "Araba başarıyla silindi.";
        public static string CarUpdated = "Araba bilgileri başarıyla güncellendi.";

        public static string CarNotAdded="Araba eklenemedi.";
        public static string CarNotDeleted = "Araba silinemedi.";
        public static string CarNotUpdated = "Araba güncellenemedi.";

        public static string AllCarGetted = "Tüm araba bilgileri getirildi.";
        public static string AllCarNotGetted = "Arabaların bilgileri getirilemedi.";

        public static string CarGettedById = "Araba getirildi";
        public static string CarNotGettedById = "Araba getirelemedi.";
    }
}
