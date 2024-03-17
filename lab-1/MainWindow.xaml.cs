using System;
using System.Collections.Generic;
using System.Windows;
using System.Xml;
using LibraryForEntrys;

namespace lab_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Parser user = new Parser();
            if (Parser.ValidateXMLWithXSD())
                new EntrysWindow().Show();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            new CreateWindow().Show();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            new DeleteRecordWindow().Show();
        }

        public static void AddNewUser(User newUser)
        {
            // Загрузка существующих пользователей из XML файла
            List<User> users = LoadUsersFromXml();

            // Добавление нового пользователя в список
            users.Add(newUser);

            // Запись списка пользователей обратно в XML файл
            WriteUsersToXml(users);
        }

        // Метод для загрузки данных из XML файла
        public static List<User> LoadUsersFromXml()
        {
            List<User> users = new List<User>();

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("C:\\Users\\Cuyeshi\\Documents\\ОТЧЁТЫ\\Лабораторные " +
                    "работы 2-ой курс (4 семестр)\\№1 ООПиП\\lab-1\\bin\\Debug\\Medical record.xml");

                // Получаем корневой элемент
                XmlNodeList entryNodes = xmlDoc.SelectNodes("/users/entry");

                // Итерируемся по каждому элементу <entry>
                foreach (XmlNode entryNode in entryNodes)
                {
                    User user = new User();
                    // Чтение данных пользователя из XML
                    user.doctorName = entryNode.SelectSingleNode("doctorName").InnerText;
                    user.patientName = entryNode.SelectSingleNode("patientName").InnerText;
                    user.birthday = entryNode.SelectSingleNode("birthday").InnerText;
                    user.height = int.Parse(entryNode.SelectSingleNode("height").InnerText);
                    user.weight = int.Parse(entryNode.SelectSingleNode("weight").InnerText);
                    user.pressure = entryNode.SelectSingleNode("pressure").InnerText;
                    user.diagnosis = entryNode.SelectSingleNode("diagnosis").InnerText;
                    user.inspectionDate = entryNode.SelectSingleNode("inspectionDate").InnerText;

                    users.Add(user);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка загрузки данных из XML!", 
                    "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            return users;
        }

        // Метод для записи данных пользователей в XML файл
        public static void WriteUsersToXml(List<User> users)
        {
            string xmlFilePath =
            "C:\\Users\\Cuyeshi\\Documents\\ОТЧЁТЫ\\Лабораторные работы 2-ой курс (4 семестр)\\№1 " +
            "ООПиП\\lab-1\\bin\\Debug\\Medical record.xml";

            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter xw = XmlWriter.Create(xmlFilePath, settings))
                {
                    xw.WriteStartDocument(); // Заголовок XML
                    xw.WriteStartElement("users"); // Открываем корневой элемент "users"

                    // Запись каждого пользователя
                    foreach (User user in users)
                    {
                        xw.WriteStartElement("entry");

                        xw.WriteElementString("doctorName", user.doctorName);
                        xw.WriteElementString("patientName", user.patientName);
                        xw.WriteElementString("birthday", user.birthday);
                        xw.WriteElementString("height", Convert.ToString(user.height));
                        xw.WriteElementString("weight", Convert.ToString(user.weight));
                        xw.WriteElementString("pressure", user.pressure);
                        xw.WriteElementString("diagnosis", user.diagnosis);
                        xw.WriteElementString("inspectionDate", user.inspectionDate);
                        xw.WriteEndElement();
                    }

                    xw.WriteEndElement(); // Закрываем корневой элемент
                    xw.WriteEndDocument(); // Закрываем документ
                    xw.Flush();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка записи в XML!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }

}
