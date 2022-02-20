using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Core.Utilities.Helpers.FileHelper
{
    public static class FileHelper
    {
        /// <summary>
        /// Resim, video vb şeyleri silmeye yarayan metod.
        /// </summary>
        /// <param name="filePath">Silenecek olan dosyanın yolu</param>
        public static void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        /// <summary>
        /// Bir dosyayı diğer bir dosya ile değiştirmeye yarayan fonksiyon.
        /// </summary>
        /// <param name="file">Yeni resim, video veya başka bir dosya.</param>
        /// <param name="filePath">Eski dosyanın yolu.</param>
        /// <param name="root">Yeni dosyanın kaydedileceği ana dizin.</param>
        /// <returns></returns>
        public static string Update(IFormFile file, string filePath, string root)
        {
            Delete(filePath);

            return Upload(file, root);
        }
        public static string Upload(IFormFile file,string root)
        {
            if (file.Length>0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                string extension = Path.GetExtension(file.FileName);
                string guid = GuidHelper.CreateGuid().ToString();
                string newPath = guid + extension;
                using (FileStream fileStream = File.Create(root+ newPath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return newPath;
                }
            }
            return null;
        }
       
    }
}
