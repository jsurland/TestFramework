using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDrivers.Infrastructure
{
    public class EnvironmentSettingsRepository
    {
        private static NameValueCollection _environmentSection;

        private static NameValueCollection EnvironmentSection
        {
            get
            {
                if (_environmentSection == null)
                    _environmentSection = ConfigurationManager.GetSection("applicationSettings/environment") as NameValueCollection;

                return _environmentSection;
            }
        }

        public static Uri TestSiteUrl => new Uri(EnvironmentSection["TestSiteUrl"]);
        public static Uri SitecoreUrl => new Uri(EnvironmentSection["SitecoreUrl"]);
        public static string WebDriversPath => EnvironmentSection["WebDriversPath"];
    }
}
