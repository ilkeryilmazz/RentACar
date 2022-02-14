using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
  public static class ColorConstants
    {
        public static string ColorAdded = "Renk başarıyla eklendi.";
        public static string ColorDeleted = "Renk başarıyla silindi.";
        public static string ColorUpdated = "Renk bilgileri başarıyla güncellendi.";

        public static string ColorNotAdded = "Renk eklenemedi.";
        public static string ColorNotDeleted = "Renk silinemedi.";
        public static string ColorNotUpdated = "Renk güncellenemedi.";

        public static string AllColorGetted = "Tüm Renk bilgileri getirildi.";
        public static string AllColorNotGetted = "Renklerin bilgileri getirilemedi.";

        public static string ColorGettedById = "Renk getirildi";
        public static string ColorNotGettedById = "Renk getirelemedi.";
        public static string ColorNameAlreadyExist = "Bu isimde bir renk zaten mevcut";
    }
}
