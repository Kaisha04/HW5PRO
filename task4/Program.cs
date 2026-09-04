// Використовуючи приклади, розглянуті на уроці, створіть свою програму для адміністратора,
//  яка зберігатиме дані конфігурації у спеціальному файлі або в реєстрі. Створіть програму користувача, зовнішнім виглядом якого можна керувати за допомогою адмінпрограми.

using System;
using Microsoft.Extensions.Configuration;

namespace task4;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Вітаю в адмін меню!");
        var cofBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
        var appSettings = new ApplicationSettings();
        cofBuilder.GetSection("Application").Bind(appSettings);
        Console.WriteLine($"Console color is set to {appSettings.ConsoleColor}");
    }
}

class ApplicationSettings
{
    public string ConsoleColor { get; set; }
    public string  NameOfUser { get; set; }

}