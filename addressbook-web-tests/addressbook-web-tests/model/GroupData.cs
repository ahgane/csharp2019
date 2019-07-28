using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;
using LinqToDB.Mapping;

namespace Addressbook_Web_Tests
{
    [Table(Name ="group_list")]

    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData(string name)
        {
            Name = name;

        }

        public GroupData()
        {
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Name.Equals(other.Name, StringComparison.Ordinal);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public GroupData(string name, string header, string footer) {
            Name = name;
            Header = header;
            Footer = footer;
        }

        public override string ToString()
        {
            return "name=" + Name + "\nheader=" + Header + "\nfooter=" +Footer;
        }

        [Column (Name = "group_name"), NotNull]
        public string Name { get; set; }

        [Column(Name = "group_header"), NotNull]
        public string Header { get; set; } = "";

        [Column(Name = "group_footer"), NotNull]
        public string Footer { get; set; } = "";

        public int CompareTo (GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return Name.CompareTo(other.Name);
        }

        [Column(Name = "group_id"), NotNull, PrimaryKey, Identity]
        public string Id { get; set; }
    }
}
