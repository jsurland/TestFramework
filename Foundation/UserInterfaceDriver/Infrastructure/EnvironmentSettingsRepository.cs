using System;
using System.Collections.Specialized;
using System.Configuration;

namespace UserInterfaceSupport.Infrastructure
{
    public class EnvironmentSettingsRepository
    {
        //private static NameValueCollection _environmentSection;

        //private static NameValueCollection EnvironmentSection
        //{
        //    get
        //    {
        //        if (_environmentSection == null)
        //            _environmentSection = ConfigurationManager.AppSettings("applicationSettings/environment") as NameValueCollection;

        //        return _environmentSection;
        //    }
        //}

        public static Uri SiteUrl => new Uri(ConfigurationManager.AppSettings["SiteUrl"]);
        public static Uri SitecoreUrl => new Uri(ConfigurationManager.AppSettings["SitecoreUrl"]);
        public static string WebDriversPath => ConfigurationManager.AppSettings["WebDriversPath"];
    }
}
