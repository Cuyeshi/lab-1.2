using System;
using System.Windows;
using System.Collections.Generic;
using System.Xml;
using LibraryForEntrys;

namespace lab_1
{
    public partial class DeleteRecordWindow : Window
    {
        private XmlDocument xmlDoc;
        public int RecordNumber { get; private set; }

        public DeleteRecordWindow()
        {
            InitializeComponent();
        }

        
        private void DeleteRecordButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<User> users = MainWindow.LoadUsersFromXml();
                int index = RecordsException.ValidateIndex(recordNumberTextBox.Text, users);
                users.RemoveAt(--index);
                MainWindow.WriteUsersToXml(users);
                MessageBox.Show("Запись удалена.", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch 
            {
                MessageBox.Show("Введён неверный номер записи!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
