using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LibraryForEntrys
{
    /// <summary>
    /// Класс исключений.
    /// </summary>
    public class RecordsException : Exception
    {
        /// <summary>
        /// Конструктор для создания собственных исключений.
        /// </summary>
        /// <param name="message"></param>
        public RecordsException(string message) : base(message)
        {
        }

        /// <summary>
        /// Метод исключения для даты.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <exception cref="RecordsException"></exception>
        public static string ValidateDate(string input)
        {
            string pattern = @"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.\d{4}$";
            
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new RecordsException("Строка с датой пуста!");
            }

            if (!Regex.IsMatch(input, pattern))
            {
                throw new RecordsException("Неверный формат даты!");
            }

            return input;
        }

        /// <summary>
        /// Метод исключения для переменных тип Int.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <exception cref="RecordsException"></exception>
        public static int ValidateInt(string input)
        {
            int result;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new RecordsException("Строка с числом пуста!");
            }

            if (!Int32.TryParse(input, out result))
            {
                throw new RecordsException("Строка с числом содержит вещественное число или текст!");
            }

            return result;
        }

        /// <summary>
        /// Метод исключения для выбора специальности.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <exception cref="RecordsException"></exception>
        public static int ValidateSpeciality(string input)
        {
            int result;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new RecordsException("Строка специальности пуста!\n");
            }

            if (!Int32.TryParse(input, out result))
            {
                throw new RecordsException("Строка специальности содержит вещественное число или текст!\n");
            }

            if (Convert.ToInt32(input) < 1 || Convert.ToInt32(input) > 7)
            {
                throw new RecordsException("Такой специальности нет!\n");
            }

            return result;
        }

        /// <summary>
        /// Метод исключения для проверки вводимого индекса для удаления записей.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="result"></param>
        /// <exception cref="RecordsException"></exception>
        public static int ValidateIndex(string input, List<User> users)
        {
            int result;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new RecordsException("Строка с числом пуста!");
            }

            if (!Int32.TryParse(input, out result))
            {
                throw new RecordsException("Строка с числом содержит вещественное число или текст!");
            }

            if (Convert.ToInt32(input) < 1 || Convert.ToInt32(input) > users.Count)
            {
                throw new RecordsException("Индекс выход за диапазон значений!\n");
            }

            return result;
        }

    }
}
