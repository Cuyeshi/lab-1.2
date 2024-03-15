using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlSaxWriting
{
    internal class User
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public DateTime Registered { get; private set; }

        public User(string name, int age, DateTime registered)
        {
            Name = name;
            Age = age;
            Registered = registered;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}", Name, Age, Registered.ToShortDateString());
        }
    }
}
