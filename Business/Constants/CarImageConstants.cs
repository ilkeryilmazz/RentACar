using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.Constants
{
    public static class CarImageConstants
    {
        public static string CarImagesLimitExceded = "Bir arabanın maksimum 5 adet resmi olabilir.";
        public static string CarImagesNotFound = "Arabaya ait bir resim bulunamadı";


        public static string CarImagesAdded = "Araba resmi başarıyla sisteme yüklendi";
        public static string CarImagesUpdated = "Araba resmi başarı ile güncellendi";
        public static string CarImagesDeleted = "Araba resmi başarı ile silindi";
        public static string CarImagesGettedByCarId = "Arabaya ait olan resimler başarıyla getirildi";
        public static string CarImagesGettedById = "Araba resmi id ile getirildi";
        public static string AllCarImagesGetted = "Tüm araba resimleri getirildi";
    }
}
