namespace WebAddressbookTests
{
    public class GroupData
    {
        private string _groupName;
        private string _groupHeader;
        private string _groupFooter;

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
