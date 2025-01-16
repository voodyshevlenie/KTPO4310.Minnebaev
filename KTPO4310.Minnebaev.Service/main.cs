using System;
using KTPO4310.Minnebaev.Lib.src.LogAn; // Импортируем пространство имен для LogAnalyzer

namespace KTPO4310.Minnebaev.Lib.src.LogAn { 
    public class MainEntry
    {
        public static void Main(string[] args)
        {
            LogAnalyzer logAnalyzer = new LogAnalyzer();

            // Примеры имен файлов для проверки
            string[] fileNames =
            {
                "logfile.log",     // Правильное расширение
                "document.txt",    // Правильное расширение
                "report.log",      // Правильное расширение
                "image.png",       // Неправильное расширение
                "archive.zip",     // Неправильное расширение
                "notes.doc"        // Неправильное расширение
            };

            foreach (var fileName in fileNames)
            {
                bool isValid = logAnalyzer.IsValidLogFileName(fileName);
                Console.WriteLine($"Файл '{fileName}' имеет допустимое расширение: {isValid}");
            }
        }
    }
}
