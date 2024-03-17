using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;

namespace XmlSaxWriting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // a collection of test users
            List<User> users = new List<User>();
            users.Add(new User("Мусафиров Алексей", "Бахонько Алексей", "20.02.2004", 162, 56, "120/60", 2, "2024.6.15"));
            users.Add(new User("Козлов Иван", "Пономаренко Михаил", "13.01.2005", 171, 74, "118/56", 1, "2024.8.30"));
            users.Add(new User("Привалов Анатолий", "Усерпов Григорий", "08.06.2003", 180, 84, "130/62", 4, "2023.11.10"));

            // the XmlWriter settings
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            // writes the users
            using (XmlWriter xw = XmlWriter.Create(@"Medical record.xml", settings))
            {
                int count = 1;
                xw.WriteStartDocument(); // the header
                xw.WriteStartElement("users"); // opens the root users element

                // writes individual users
                foreach (User u in users)
                {
                    
                    xw.WriteStartElement("entry");
                    xw.WriteAttributeString("number", Convert.ToString(count));

                    xw.WriteElementString("doctorName", u.doctorName);
                    xw.WriteElementString("patientName", u.patientName);
                    xw.WriteElementString("birthday", u.birthday);
                    xw.WriteElementString("height", Convert.ToString(u.height));
                    xw.WriteElementString("weight", Convert.ToString(u.weight));
                    xw.WriteElementString("pressure", u.pressure);
                    xw.WriteElementString("diagnosis", u.diagnosis);
                    xw.WriteElementString("inspectionDate", u.inspectionDate);
                    xw.WriteEndElement();
                    count++;
                }

                xw.WriteEndElement(); // closes the root element
                xw.WriteEndDocument(); // closes the document
                xw.Flush();
            }

            using (XmlReader xr = XmlReader.Create(@"file.xml"))
            {
                string name = "";
                int age = 0;
                DateTime registered = DateTime.Now;
                string element = "";
                while (xr.Read())
                {
                    // reads the element
                    if (xr.NodeType == XmlNodeType.Element)
                    {
                        element = xr.Name; // the name of the current element
                        if (element == "user")
                        {
                            age = int.Parse(xr.GetAttribute("age"));
                        }
                    }
                    // reads the element value
                    else if (xr.NodeType == XmlNodeType.Text)
                    {
                        switch (element)
                        {
                            case "name":
                                name = xr.Value;
                                break;
                            case "registered":
                                registered = DateTime.Parse(xr.Value);
                                break;
                        }
                    }
                    /* reads the closing element
                    else if ((xr.NodeType == XmlNodeType.EndElement) && (xr.Name == "user"))
                        users.Add(new User(name, age, registered));*/
                }

                // printing the loaded objects
                foreach (User u in users)
                {
                    Console.WriteLine(u);
                }
                Console.ReadKey();
            }
        }
    }
}
