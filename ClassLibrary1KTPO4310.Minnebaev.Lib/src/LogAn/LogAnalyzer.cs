using System;

namespace KTPO4310.Minnebaev.Lib.src.LogAn
{
    public class LogAnalyzer
    {
        public bool WasLastFileNameValid { get; private set; }
        public bool IsValidLogFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                WasLastFileNameValid = false;
                return false;
            }

            WasLastFileNameValid = fileName.EndsWith(".LOG", StringComparison.OrdinalIgnoreCase);
            return WasLastFileNameValid;
        }
    }
}