
using Google.Cloud.Translation.V2;

string keyFilePath = @"C:\Users\maslo\Desktop\homework10-407901-51543db07a37.json";

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", keyFilePath);
            var client = TranslationClient.Create();
            var supportedLanguages = client.ListLanguages();
            Console.WriteLine("Supported Languages:");
            var languageDictionary = new Dictionary<string, string>();
            //here you see the list of languages
            foreach (var language in supportedLanguages)
            {
                Console.WriteLine($"{language.Code}: {language.Name}");
                languageDictionary[language.Code] = language.Name;
            }
            Console.Write("Enter the text to be translated: ");
            string text = Console.ReadLine();
            Console.Write("Enter the target language code (for example: 'ru' for Russian): ");
            string targetLanguageCode = Console.ReadLine();
            if (languageDictionary.TryGetValue(targetLanguageCode, out var targetLanguageName))
            {
                Console.WriteLine($"Selected language: {targetLanguageName}");
            }
            else
            {
                Console.WriteLine("Invalid language code. Using default.");
                targetLanguageCode = "en"; // Use English as the default language
            }
            try
            {
                var response = client.TranslateText(text, targetLanguageCode);
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine($"Original: {text}");
                Console.WriteLine($"Translated: {response.TranslatedText}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }