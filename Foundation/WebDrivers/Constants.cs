namespace WebDrivers
{
    public struct Constants
    {
        public enum BrowserType
        {
            None,
            InternetExplorer,
            Edge,
            FireFox,
            Safari,
            Chrome,
            Android
        }
        
        public enum OperatingSystem
        {
            None = 0,
            Windows = 1,
            IPad = 2,
            IPhone = 3,
            GalaxyTab = 4,
            GalaxyS7 = 5
        }

        public struct Timeouts
        {
            public const int DefaultPollingTimeout = 10;
            public const int PageLoadTimeout = 30;
            public const int BrowserStackDefaultPollingTimeout = 30;
            public const int BrowserStackCommandTimeout = 88;
            public const int BrowserStackPageLoadTimeout = 80;
        }
    }
}