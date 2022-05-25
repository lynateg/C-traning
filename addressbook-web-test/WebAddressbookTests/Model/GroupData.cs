using System;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        private string _groupName;
        private string _groupHeader;
        private string _groupFooter;
        private string name;

        public GroupData(string text)
        {
            this.name = text;
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other,null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return name == other.name;
        }
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
        public override string ToString()
        {
            return "name=" + name;
        }
        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return name.CompareTo(other.name);
        }

        public GroupData(string groupName, string groupHeader, string groupFooter)
        {
            _groupName = groupName;
            _groupHeader = groupHeader;
            _groupFooter = groupFooter;
        }
        public string GroupName
        {
            get { return _groupName; }
            //set { _groupName = value; }
        }
        public string GroupHeader
        {
            get { return _groupHeader; }
            //set { _groupHeader = value; }
        }
        public string GroupFooter
        {
            get { return _groupFooter; }
            //set { _groupFooter = value; }
        }
    }
}
