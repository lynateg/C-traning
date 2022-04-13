namespace WebAddressbookTests
{
    public class Test
    {
        public void Do()
        {
            var x = new AccountData("1", "2");

            var y = new AccountDataEasy() { Username = "1", Password = "2" };

            var z = new AccountDataEasy();
            z.Username = "1";
            z.Password = "2";
        }
    }

    public class AccountData
    {
        private string _username;
        private string _password;

        public AccountData(string username, string password)
        {
            _username = username;
            _password = password;
        }
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
    }

    public class AccountDataEasy
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}


