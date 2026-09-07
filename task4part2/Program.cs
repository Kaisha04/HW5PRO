using System;
using Microsoft.Extensions.Configuration;
using task4;

namespace task4part2;

class Program
{
    static void Main(string[] args)
    {

        string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        string myAppFolder = Path.Combine(appDataFolder, "MySharedApp");

        if (!Directory.Exists(myAppFolder))
        {
            Console.WriteLine("Файл appsettings.json не знайдено. Будь ласка, запустіть програму адміністрування для створення файлу.");
            return;
        }

        string configFilePath = Path.Combine(myAppFolder, "appsettings.json");
        if (!File.Exists(configFilePath))
        {
            Console.WriteLine("Файл appsettings.json не знайдено. Будь ласка, запустіть програму адміністрування для створення файлу.");
            return;
        }
        Console.WriteLine("Вітаю в програмі користувача!");

        var appSettings = new ApplicationSettings();
        var userSettings = new UserSettings();
        var cofBuilder = new ConfigurationBuilder().AddJsonFile(configFilePath, optional: true, reloadOnChange: true).Build();

        cofBuilder.GetSection("ApplicationSettings").Bind(appSettings);
        cofBuilder.GetSection("UserSettings").Bind(userSettings);
        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), appSettings.ConsoleColor);
        cofBuilder.GetSection("UserSettings").Bind(userSettings);
        Console.WriteLine($"Hello, {userSettings.NameOfUser}!");
    }
}