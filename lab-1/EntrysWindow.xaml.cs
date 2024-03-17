using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace lab_1
{
    public partial class EntrysWindow : Window
    {
        public EntrysWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            List<MedicalEntry> entries = new List<MedicalEntry>();

            // Load data from XML file
            XDocument doc = XDocument.Load("C:\\Users\\Cuyeshi\\Documents\\ОТЧЁТЫ\\Лабораторные работы 2-ой курс (4 семестр)\\№1 ООПиП\\lab-1\\bin\\Debug\\Medical record.xml");
            foreach (XElement element in doc.Root.Elements("entry"))
            {
                MedicalEntry entry = new MedicalEntry
                {
                    DoctorName = element.Element("doctorName").Value,
                    PatientName = element.Element("patientName").Value,
                    Birthday = element.Element("birthday").Value,
                    Height = int.Parse(element.Element("height").Value),
                    Weight = int.Parse(element.Element("weight").Value),
                    Pressure = element.Element("pressure").Value,
                    Diagnosis = element.Element("diagnosis").Value,
                    InspectionDate = element.Element("inspectionDate").Value,
                };
                entries.Add(entry);
            }

            // Bind data to DataGrid
            dataGrid.ItemsSource = entries;
        }
    }

    public class MedicalEntry
    {
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public string Birthday { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Pressure { get; set; }
        public string Diagnosis { get; set; }
        public string InspectionDate { get; set; }
    }
}
