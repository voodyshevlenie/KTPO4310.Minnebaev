using KTPO4310.Minnebaev.Lib.src.LogAn;
using NUnit.Framework;
using System;

namespace KTPO4310.Minnebaev.Lib.src.LogAn
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [TearDown]
        public void AfterEachTest()
        {
            // Сброс глобального состояния, устанавливаем менеджер расширений в null
            ExtensionManagerFactory.SetManager(null);
        }

        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            // Подготовка теста
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = true;
            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer log = new LogAnalyzer(); // Создаем экземпляр без параметров

            // Воздействие на тестируемый объект
            bool result = log.IsValidLogFileName("short.ext");

            // Проверка ожидаемого результата
            Assert.True(result);
        }

        [Test]
        public void IsValidLogFileName_WithUnsupportedExtension_ReturnsFalse()
        {
            // Подготовка теста
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillBeValid = false;
            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer log = new LogAnalyzer(); // Создаем экземпляр без параметров

            // Воздействие на тестируемый объект
            bool result = log.IsValidLogFileName("file.bad");

            // Проверка ожидаемого результата
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            // Подготовка теста
            FakeExtensionManager fakeManager = new FakeExtensionManager();
            fakeManager.WillThrow = new Exception("Test exception");
            ExtensionManagerFactory.SetManager(fakeManager);

            LogAnalyzer log = new LogAnalyzer(); // Создаем экземпляр без параметров

            // Воздействие на тестируемый объект
            bool result = log.IsValidLogFileName("test.log");

            // Проверка ожидаемого результата
            Assert.IsFalse(result);
        }
    }

    /// <summary> Поддельный менеджер расширений </summary>
    internal class FakeExtensionManager : IExtensionManager
    {
        /// <summary> Это позволяет настроить
        /// поддельный результат для метода IsValid </summary>
        public bool WillBeValid = false;

        public Exception WillThrow = null;

        public bool IsValid(string fileName)
        {

            return WillBeValid;
        }
    }
}
