    // Використовуючи приклади, розглянуті на уроці, створіть свою програму для адміністратора,
    //  яка зберігатиме дані конфігурації у спеціальному файлі або в реєстрі. Створіть програму користувача, зовнішнім виглядом якого можна керувати за допомогою адмінпрограми.

    using System;
    using Newtonsoft.Json;

    namespace task4;

    class Program
    {
        static void Main(string[] args)
        {
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string myAppFolder = Path.Combine(appDataFolder, "MySharedApp");

            if (!Directory.Exists(myAppFolder))
            {
                Directory.CreateDirectory(myAppFolder);
            }

            string configFilePath = Path.Combine(myAppFolder, "appsettings.json");


            System.Console.WriteLine(configFilePath);
            Console.WriteLine("Вітаю в адмін меню!");

            Console.WriteLine("Введіть колір консолі (наприклад, Red, Green, Blue):");
            string consoleColor = Console.ReadLine();
            Console.WriteLine("Введіть ім'я користувача:");
            string nameOfUser = Console.ReadLine();


            ApplicationSettings appSettings = new ApplicationSettings(consoleColor);
            UserSettings userSettings = new UserSettings(nameOfUser);

            var configData = new Dictionary<string, object>
            {
                { nameof(ApplicationSettings), appSettings },
                { nameof(UserSettings), userSettings }
            };

            string jsonOutput = JsonConvert.SerializeObject(configData, Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(configFilePath))
            {
                writer.Write(jsonOutput);
            }
            Console.WriteLine("Налаштування збережено у файлі appsettings.json.");
        }
        static void SaveSection(string filePath, string sectionName, object data)
        {
            string json = File.Exists(filePath) ? File.ReadAllText(filePath) : "{}";

        }
    }

    public class ApplicationSettings
    {
        public string ConsoleColor { get; set; }

        public ApplicationSettings(string consoleColor = "White")
        {
            ConsoleColor = consoleColor;
        }
        public ApplicationSettings()
        {
        }
    }

    public class UserSettings
    {
        public string NameOfUser { get; set; }

        public UserSettings(string nameOfUser = "User")
        {
            NameOfUser = nameOfUser;
        }
        public UserSettings()
        {
        }
    }