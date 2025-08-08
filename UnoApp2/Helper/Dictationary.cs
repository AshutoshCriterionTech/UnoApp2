using System.Collections.Generic;

namespace UnoApp2.Helper
{
    internal static class Dictationary
    {
        private static Dictionary<string, string> EnglishWords = new()
        {
            { "greeting", "Hello" },
            { "exit", "Exit" },
            { "submit", "Submit" },
            { "enter_username", "Enter Username" },
            { "enter_password", "Enter Password" },
            { "login", "Login" },
            { "welcome", "Welcome" },
        };

        private static Dictionary<string, string> HindiWords = new()
        {
            { "greeting", "नमस्ते" },
            { "exit", "बाहर जाएं" },
            { "submit", "जमा करें" },
            { "enter_username", "उपयोगकर्ता नाम दर्ज करें" },
            { "enter_password", "पासवर्ड दर्ज करें" },
            { "login", "लॉगिन करें" },
            { "welcome", "स्वागत है" },
        };

        private static string _currentLanguage = "en";

        public static void SetLanguage(string langCode)
        {
            _currentLanguage = langCode;
        }

        public static string Translate(string key)
        {
            return _currentLanguage switch
            {
                "hi" => HindiWords.TryGetValue(key, out var hindiWord) ? hindiWord : key,
                _ => EnglishWords.TryGetValue(key, out var englishWord) ? englishWord : key,
            };
        }
    }
}
