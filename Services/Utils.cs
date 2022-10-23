using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApiAuth.Services
{
    public class Utils
    {
        public static String sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
        #region Manipulação de arquivos
        public static string GetFileFormat(string fullFileName)
        {
            var format = fullFileName.Split(".").Last();
            return "." + format;
        }

        public static List<string> SaveFiles(IFormFileCollection files, string directoryPath)
        {

            List<string> path = new List<string>();
            foreach (var file in files)
            {
                
                string fileName = (Guid.NewGuid().ToString() + GetFileFormat(file.FileName));
                string directory = CreateFilePath(fileName, directoryPath);
                #region Salva o arquivo em disco
                byte[] bytesFile = ConvertFileInByteArray(file);
                System.IO.File.WriteAllBytesAsync(directory, bytesFile);
                
                
                using (var stream = new FileStream(directory, FileMode.Create))
                {
                    file.CopyTo(stream);

                }
                #endregion



                path.Add(directory);
            }

            return path;

        }
        public static string CreateFilePath(string fileName, string directoryPath)
        {

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, fileName);

            return filePath;
        }

        public static string GetFileUrl(string filePath, string baseUrl, string imagesPath)
        {

            var fileUrl = imagesPath
                .Replace("wwwroot", "")
                .Replace("\\", "");

            return (baseUrl + "/" + fileUrl + "/" + filePath);
        }

        public static byte[] ConvertFileInByteArray(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
        public static void DeleteFile(string path)
        {
            if(File.Exists(path))
            {
                File.Delete(path);
            }
        }
        #endregion
    }
}

