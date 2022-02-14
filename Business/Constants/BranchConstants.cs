using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class BranchConstants
    {
        public static string AllBranchGetted = "Tüm şubeler getirildi";
        public static string BranchGettedById = "Şube getirildi";

        public static string BranchDeleted = "Şube silindi.";
        public static string BranchUpdated = "Şube güncellendi";
        public static string BranchAdded = "Şube eklendi.";
        public static string BranchLimitExceeded = "Ekleyebileceğiniz maksimum şube limiti aşıldı";
        public static string BranchNameAlreadyExist = "Bu isime ait bir şube zaten mevcut";
    }
}
