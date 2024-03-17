using LibraryForEntrys;
using System;
using System.Windows;

namespace lab_1
{
    public partial class CreateWindow : Window
    {
        public CreateWindow()
        {
            InitializeComponent();
        }

        private void AddRecordButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Создаем нового пользователя на основе введенных данных
                User newUser = new User
                {
                    doctorName = doctorNameTextBox.Text,
                    patientName = patientNameTextBox.Text,
                    birthday = RecordsException.ValidateDate(birthdayTextBox.Text),
                    height = RecordsException.ValidateInt(heightTextBox.Text),
                    weight = RecordsException.ValidateInt(weightTextBox.Text),
                    pressure = pressureTextBox.Text,
                    diagnosis = User.EnumerationExtract(RecordsException.ValidateSpeciality(diagnosisTextBox.Text)),
                    inspectionDate = RecordsException.ValidateDate(inspectionDateTextBox.Text)
                };
                // Вызываем метод для добавления нового пользователя в XML файл
                MainWindow.AddNewUser(newUser);

                MessageBox.Show("Запись добавлена!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        
    }
}
