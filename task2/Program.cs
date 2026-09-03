// Створіть програму, яка виводить на екран всю інформацію про вказаний .xml файл.

 using System;  
using System.Xml;
 namespace Task2  
 {  
     class Program  
     {  
        public static  string fileName = @"file.xml"; // Вкажіть шлях до вашого .xml файлу
         static void Main(string[] args)
        {
            var doc = new FileInfo(fileName);
            if (!doc.Exists)
            {
                Console.WriteLine($"Файл {fileName} не знайдено.");
                return;
            }
            Console.WriteLine($"Інформація про файл {fileName}:");
            Console.WriteLine($"Шлях: {doc.FullName}");
            Console.WriteLine($"Розмір: {doc.Length} байт");
            Console.WriteLine($"Дата створення: {doc.CreationTime}");
            Console.WriteLine($"Дата останнього доступу: {doc.LastAccessTime}");
            Console.WriteLine($"Дата останньої зміни: {doc.LastWriteTime}");

            var docXml = new XmlDocument();
            docXml.Load(fileName);
            Console.WriteLine($"Кореневий елемент: {docXml.DocumentElement.Name}");
            Console.WriteLine($"Кількість дочірніх елементів: {docXml.DocumentElement.ChildNodes.Count}");
            Console.WriteLine($"Атрибути кореневого елемента: {docXml.DocumentElement.Attributes.Count}");
            Console.WriteLine(docXml.InnerText);
            Console.WriteLine(docXml.OuterXml);
            
        }  
     }  
 }