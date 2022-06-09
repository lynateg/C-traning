using System;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class UserData : IEquatable<UserData>, IComparable<UserData>
    {
        public string _firstname;
        public string _middlename;
        public string _lastname;
        public string _nickname;
        private string allPhones;
        private string allEmails;
        private string allContactDetails;

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
        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }
        private string MakeEmailToConcat(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
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
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (MakeEmailToConcat(Email) + MakeEmailToConcat(Email2) + MakeEmailToConcat(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        public string AllContactDetails
        {
            get
            {
                if (allContactDetails != null || allContactDetails != "")
                {
                    return allContactDetails;
                }
                else
                {
                    allContactDetails = "";
                    if (_firstname == null || _firstname == "")
                    {
                        allContactDetails += _firstname + " ";
                    }

                    if (_lastname == null || _lastname == "")
                    {
                        allContactDetails += _lastname + "\r\n";
                    }

                    if (Address == null || Address == "")
                    {
                        allContactDetails += Address + "\r\n\r\n";
                    }

                    if (HomePhone == null || HomePhone == "")
                    {
                        allContactDetails += "H: " + HomePhone + "\r\n";
                    }

                    if (MobilePhone == null || MobilePhone == "")
                    {
                        allContactDetails += "M: " + MobilePhone + "\r\n";
                    }

                    if (WorkPhone == null || WorkPhone == "")
                    {
                        allContactDetails += "W: " + WorkPhone + "\r\n";
                    }

                    if (Email == null || Email == "")
                    {
                        allContactDetails += Email + "\r\n";
                    }

                    if (Email2 == null || Email2 == "")
                    {
                        allContactDetails += Email2 + "\r\n";
                    }

                    if (Email3 == null || Email3 == "")
                    {
                        allContactDetails += Email3;
                    }

                    return allContactDetails.Trim();
                }
            }
            set
            {
                allContactDetails = value;
            }
        }
    }
}
