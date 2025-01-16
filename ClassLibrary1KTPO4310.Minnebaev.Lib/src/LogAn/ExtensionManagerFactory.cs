using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace KTPO4310.Minnebaev.Lib.src.LogAn
{
    /// <summary>Фабрика диспетчеров расширений файлов</summary>
    public class ExtensionManagerFactory
    {
        private static IExtensionManager customManager = null;

        /// <summary>Создание объектов</summary>
        public static IExtensionManager Create()
        {
            if (customManager != null)
            {
                return customManager;
            }

            return new FileExtensionManager();
        }

        /// <summary> Метод позволит тестам контроллировать,
        /// что возвращает фабрика</summary>
        /// <param name="mgr"></param>
        public static void SetManager(IExtensionManager mgr)
        {
            customManager = mgr;
        }
    }
}
