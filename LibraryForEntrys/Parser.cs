using System;
using System.Xml;
using System.Xml.Schema;

namespace LibraryForEntrys
{
    /// <summary>
    /// Класс для проверки соответствию XSD схеме
    /// </summary>
    public class Parser
    {
        public static bool ValidateXMLWithXSD()
        {
            string xmlFilePath = "C:\\Users\\Cuyeshi\\Documents\\ОТЧЁТЫ\\Лабораторные работы 2-ой курс (4 семестр)\\№1 ООПиП\\lab-1\\bin\\Debug\\Medical record.xml";
            string xsdFilePath = "C:\\Users\\Cuyeshi\\Documents\\ОТЧЁТЫ\\Лабораторные работы 2-ой курс (4 семестр)\\№1 ООПиП\\lab-1\\bin\\Debug\\Medical_recordSchema.xsd";
            try
            {
                // Создание XmlReaderSettings для включения проверки схемы
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.Schemas.Add(null, xsdFilePath);
                settings.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);

                // Создание XmlReader для чтения XML файла
                using (XmlReader reader = XmlReader.Create(xmlFilePath, settings))
                {
                    // Чтение XML файла
                    while (reader.Read()) { }
                }

                return true; // Валидация успешна
            }
            catch (Exception ex)
            {                
                return false; // Валидация неуспешна
            }
        }

        private static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            Console.WriteLine($"Ошибка валидации: {e.Message}");
        }

    }
}
