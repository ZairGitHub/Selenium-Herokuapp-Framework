using System.Configuration;

namespace SeleniumExamples
{
    public static class ConfigReader
    {
        public static readonly string Base =
            ConfigurationManager.AppSettings["base"];

        public static readonly string Index =
            ConfigurationManager.AppSettings["index"];

        public static readonly string Invalid =
            ConfigurationManager.AppSettings["invalid"];

        public static readonly string AddRemoveElements =
            ConfigurationManager.AppSettings["add_remove_elements"];

        public static readonly string BasicAuthentication =
            ConfigurationManager.AppSettings["basic_authentication"];

        public static readonly string Checkboxes =
            ConfigurationManager.AppSettings["checkboxes"];

        public static readonly string DigestAuthentication =
            ConfigurationManager.AppSettings["digest_authentication"];

        public static readonly string FormAuthetication =
            ConfigurationManager.AppSettings["form_authentication"];

        public static readonly string Frames =
            ConfigurationManager.AppSettings["frames"];

        public static readonly string SecureArea =
            ConfigurationManager.AppSettings["secure_area"];

        public static readonly string Hovers =
            ConfigurationManager.AppSettings["hovers"];

        public static readonly string JavaScriptAlerts =
            ConfigurationManager.AppSettings["javascript_alerts"];
    }
}
