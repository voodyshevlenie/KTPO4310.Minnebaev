using NUnit.Framework;
using KTPO4310.Minnebaev.Lib.src.LogAn;
using System;

namespace KTPO4310.Minnebaev.Lib.src.LogAn
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_BadExtension_ReturnFalse()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("validlogfile.LOG");
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("validlogfile.log");
            Assert.IsTrue(result);
        }

        [TestCase("validlogfile.LOG", true)]
        [TestCase("validlogfile.log", true)]
        [TestCase("validlogfile.LOg", true)]
        [TestCase("invalidfile.foo", false)]

        public void IsValidLogFileName_ValidExtension_ReturnsTrue(string fileName, bool expectedResult)
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName(fileName);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase("badfile.foo", false)]
        [TestCase("goodfale.log", true)]
        public void IsValidLogFileName_WhenCalled_ChangesWasLastFileNameValid(string fileName, bool expected) 
        { 
            LogAnalyzer analyzer = new LogAnalyzer();

            analyzer.IsValidLogFileName(fileName);

            Assert.AreEqual(expected, analyzer.WasLastFileNameValid);
        }
    }
}
