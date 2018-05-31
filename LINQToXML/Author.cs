using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQToXML
{
    class Author
    {
        public Author(string firstAndLastName)
        {
            int index = firstAndLastName.IndexOf(", ");
            LastName = firstAndLastName.Substring(0, index);
            FirstName = firstAndLastName.Substring(index + 2, (firstAndLastName.Length - LastName.Length) - 2);
        }

        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public String FirstName { get; set; }
        public String LastName { get; set; }

        public override string ToString()
        {
            return LastName + " " + FirstName;
        }
    }
}
