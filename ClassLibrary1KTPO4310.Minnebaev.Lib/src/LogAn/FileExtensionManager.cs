using System;
using System.Configuration;
using System.Linq;

namespace KTPO4310.Minnebaev.Lib.src.LogAn
{
    /// <summary>Менеджер расширений файлов</summary>
    public class FileExtensionManager : IExtensionManager
    {
        private string _validExtensionsString;

        /// <summary>проверка правильности расширения</summary>
        public FileExtensionManager()
        {
            _validExtensionsString = ConfigurationManager.AppSettings["logfileextensions"];
            if (string.IsNullOrEmpty(_validExtensionsString))
            {
                _validExtensionsString = ".log"; //Fallback default
            }
        }

        public bool IsValid(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return false;
            }

            var validExtensions = _validExtensionsString.Split(',')
                .Select(ext => ext.Trim())
                .Where(ext => !string.IsNullOrEmpty(ext))
                .ToArray();

            return validExtensions.Any(ext => fileName.EndsWith(ext, StringComparison.OrdinalIgnoreCase));
        }
    }
}