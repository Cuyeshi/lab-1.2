using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace XmlSaxWriting
{
    internal class User
    {
        public string doctorName;
        public string patientName;
        public string birthday;
        public int height;
        public int weight;
        public string pressure;
        public string diagnosis;
        public string inspectionDate;

        enum Diagnosis
        {
            Подагра = 1,
            Рак = 2,
            Изжога = 3,
            Синусит = 4,
            Диабет = 5,
            Кифоз = 6,
            ВИЧ = 7,
        }

        public User (string doctorName, string patientName, string birthday, 
            int height, int weight, string pressure, int diagnosis, string inspectionDate)
        {
            this.doctorName = doctorName;
            this.patientName = patientName;
            this.birthday = birthday;
            this.height = height;
            this.weight = weight;
            this.pressure = pressure;
            this.diagnosis = User.EnumerationExtract(diagnosis);
            this.inspectionDate = inspectionDate;
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

            string spec = "";
            // Обращение к элементу по индексу
            if (index > 0 && index < DiagnosisArray.Length)
            {
                spec = DiagnosisArray[index].ToString();
            }
            return spec;
        }
    }
}
