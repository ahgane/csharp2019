using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook_Web_Tests
{
   public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name && Surname == other.Surname;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name" + Name + "surname" + Surname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return (Name.CompareTo(other.Name) & Surname.CompareTo(other.Surname));
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; } = "";

        public string Mobile { get; set; } = "";
        public string Id { get; set; }

    }
}
