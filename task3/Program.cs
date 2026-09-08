// З файлу TelephoneBook.xml (файл повинен був бути створений у процесі виконання додаткового завдання) виведіть на екран лише номери телефонів.

using System;
using System.Linq;
using System.Xml.Linq;

namespace task3;

class Program
{
    static void Main()
    {
                     string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        string myAppFolder = Path.Combine(appDataFolder, "TelephoneBookApp");

        if (!Directory.Exists(myAppFolder))
        {
            Directory.CreateDirectory(myAppFolder);
        }

        string configFilePath = Path.Combine(myAppFolder, "TelephoneBook.xml");
        XDocument doc = XDocument.Load(configFilePath);

        XElement Contacts = doc.Element("MyContacts");
        string[] arrayOfNumbers = Contacts.Elements("Contact")
            .Select(contact => contact.Attribute("TelephoneNumber").Value)
            .ToArray();

        Console.WriteLine("Номери телефонів:");
        foreach (string number in arrayOfNumbers)
        {
            Console.WriteLine(number);
        }
    }
}