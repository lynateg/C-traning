namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected ApplicationManager _manager;
        protected string _baseURL;
        public HelperBase(ApplicationManager manager)
        {
            _manager = manager;
            _baseURL = manager.BaseURL;
        }

    }
}