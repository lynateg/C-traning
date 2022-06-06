using System;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public string _groupName;
        public string _groupHeader;
        public string _groupFooter;
       
        public GroupData(string _groupName)
        {            
            this._groupName = _groupName;
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
            return _groupName == other._groupName;
        }
        public override int GetHashCode()
        {
            return _groupName.GetHashCode();
        }
        public override string ToString()
        {
            return "name=" + _groupName;
        }
        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return _groupName.CompareTo(other._groupName);
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
