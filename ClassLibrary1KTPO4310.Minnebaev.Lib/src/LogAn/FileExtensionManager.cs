using System;
using KTPO4310.Minnebaev.Lib.src.LogAn;
using System.Configuration;

namespace KTPO4310.Minnebaev.Lib.src.LogAn
{
    /// <summary>Менеджер расширений файлов</summary>
    public class FileExtensionManager : IExtensionManager
    {
        /// <summary>проверка правильности расширения</summary>

        public FileExtensionManager()
        {
            string configvalue2 = ConfigurationManager.AppSettings["logfilelocation"];
        }

        public bool IsValid(string fileName)
        {
            //читать конфигурационный файл
            //вернуть true
            //если конфигурация поддерживается

            throw new NotImplementedException();
        }
    }
}