using System;

namespace LibraryForEntrys
{
    /// <summary>
    /// Класс для храения данных медицинских карточек.
    /// </summary>
    public class User
    {
        public string doctorName;
        public string patientName;
        public string birthday;
        public int height;
        public int weight;
        public string pressure;
        public string diagnosis;
        public string inspectionDate;

        public enum Diagnosis
        {
            Подагра,
            Рак,
            Изжога,
            Синусит,
            Диабет,
            Кифоз,
            ВИЧ,
        }

        public User ()
        {
            this.doctorName = null;
            this.patientName = null;
            this.birthday = null;
            this.height = 0;
            this.weight = 0;
            this.pressure = null;
            this.diagnosis = null;
            this.inspectionDate = null;
        }

        public User(string doctorName, string patientName, string birthday,
            int height, int weight, string pressure, int diagnosisIndex, string inspectionDate)
        {
            this.doctorName = doctorName;
            this.patientName = patientName;
            this.birthday = birthday;
            this.height = height;
            this.weight = weight;
            this.pressure = pressure;
            this.inspectionDate = inspectionDate;

            switch (diagnosisIndex)
            {
                case 1:
                    diagnosis = Convert.ToString(Diagnosis.Подагра);
                    break;

                case 2:
                    diagnosis = Convert.ToString(Diagnosis.Рак);
                    break;

                case 3:
                    diagnosis = Convert.ToString(Diagnosis.Изжога);
                    break;

                case 4:
                    diagnosis = Convert.ToString(Diagnosis.Синусит);
                    break;

                case 5:
                    diagnosis = Convert.ToString(Diagnosis.Диабет);
                    break;

                case 6:
                    diagnosis = Convert.ToString(Diagnosis.Кифоз);
                    break;

                case 7:
                    diagnosis = Convert.ToString(Diagnosis.ВИЧ);
                    break;

                default:
                    diagnosis = Convert.ToString(Diagnosis.Подагра);
                    break;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", doctorName, patientName, birthday, 
                height, weight, pressure, diagnosis, inspectionDate);
        }

        public static string EnumerationExtract(int index)
        {
            // Получение всех значений перечисления в массив
            Diagnosis[] DiagnosisArray = (Diagnosis[])Enum.GetValues(typeof(Diagnosis));

            index--;
            string spec = "";
            // Обращение к элементу по индексу
            if (index >= 0 && index < DiagnosisArray.Length)
            {
                spec = DiagnosisArray[index].ToString();
            }
            return spec;
        }
    }
}
