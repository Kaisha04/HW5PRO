// Створіть .xml файл, який би відповідав наступним вимогам:

// • ім'я файлу: TelephoneBook.xml

// • кореневий елемент: “MyContacts”

// • тег “Contact”, і в ньому має бути записано ім'я контакту та атрибут “TelephoneNumber” зі значенням номера телефону.

using System;
using System.Xml.Linq;

namespace task6

{

    class Program

    {

        static void Main(string[] args)

        {
             string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        string myAppFolder = Path.Combine(appDataFolder, "TelephoneBookApp");

        if (!Directory.Exists(myAppFolder))
        {
            Directory.CreateDirectory(myAppFolder);
        }

        string configFilePath = Path.Combine(myAppFolder, "TelephoneBook.xml");
            var rootElement = new XElement("MyContacts");
            rootElement.Add(new XElement("Contact", new XAttribute("TelephoneNumber", "123-456-7890"), "John Doe"));
            rootElement.Add(new XElement("Contact", new XAttribute("TelephoneNumber", "987-654-3210"), "Jane Smith"));
            rootElement.Add(new XElement("Contact", new XAttribute("TelephoneNumber", "555-555-5555"), "Bob Johnson"));
            rootElement.Save(configFilePath);
            Console.WriteLine("XML файл створено та збережено за шляхом: " + configFilePath);
        }

    }

}