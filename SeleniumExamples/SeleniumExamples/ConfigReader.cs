using System.Configuration;

namespace SeleniumExamples
{
    public static class ConfigReader
    {
        public static readonly string BaseUrl =
            ConfigurationManager.AppSettings["base_url"];

        public static readonly string AddRemoveElements =
            ConfigurationManager.AppSettings["add_remove_elements"];

        public static readonly string BasicAuthentication =
            ConfigurationManager.AppSettings["basic_authentication"];

        public static readonly string FormAuthetication =
            ConfigurationManager.AppSettings["form_authentication"];
    }
}
