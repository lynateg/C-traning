namespace WebAddressbookTests
{
    public class UserData
    {
        private string _firstname;
        private string _middlename;
        private string _lastname;
        private string _nickname;

        public UserData(string firstname, string middlename, string lastname, string nickname)
        {
            _firstname = firstname;
            _middlename = middlename;
            _lastname = lastname;
            _nickname = nickname;
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
