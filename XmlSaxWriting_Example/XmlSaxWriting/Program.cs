using System;
using System.Collections.Generic;
using System.Xml;

namespace XmlSaxWriting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // a collection of test users
            List<User> users = new List<User>();
            users.Add(new User("John Smith", 22, new DateTime(2000, 3, 21)));
            users.Add(new User("James Brown", 31, new DateTime(2016, 10, 30)));
            users.Add(new User("Tom Hanks", 16, new DateTime(2011, 1, 12)));

            // the XmlWriter settings
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            // writes the users
            using (XmlWriter xw = XmlWriter.Create(@"file2.xml", settings))
            {
                xw.WriteStartDocument(); // the header
                xw.WriteStartElement("users"); // opens the root users element

                // writes individual users
                foreach (User u in users)
                {
                    xw.WriteStartElement("user");
                    xw.WriteAttributeString("age", u.Age.ToString());

                    xw.WriteElementString("name", u.Name);
                    xw.WriteElementString("registered", u.Registered.ToShortDateString());
                    xw.WriteEndElement();

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
