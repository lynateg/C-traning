using System;

namespace WebAddressbookTests
{
    public class UserData : IEquatable<UserData>, IComparable<UserData>
    {
        public string _firstname;
        public string _middlename;
        public string _lastname;
        public string _nickname;

        public UserData(string _firstname, string _lastname)
        {
            this._firstname = _firstname;
            this._lastname = _lastname;
        }
        public UserData(string firstname, string middlename, string lastname, string nickname)
        {
            _firstname = firstname;
            _middlename = middlename;
            _lastname = lastname;
            _nickname = nickname;
        }

        public bool Equals(UserData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            if ((_firstname == other._firstname))
            {
                return _lastname == other._lastname;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return _firstname.GetHashCode() + _lastname.GetHashCode();
        }
        public override string ToString()
        {
            return "firstname=" + _firstname + "\n" + "lastname=" + _lastname;
        }

        public int CompareTo(UserData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (_firstname.CompareTo(other._firstname) == 0)
            {
                return _lastname.CompareTo(other._lastname);
            }
            else
            {
                return _firstname.CompareTo(other._firstname);
            }
        }

        public string Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
            }
        }
        public string Middlename
        {
            get
            {
                return _middlename;
            }
            set
            {
                _middlename = value;
            }
        }
        public string Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
            }
        }
        public string Nickname
        {
            get
            {
                return _nickname;
            }
            set
            {
                _nickname = value;
            }
        }
    }
}
