using System.Configuration;

namespace SeleniumHerokuApp
{
    public static class ConfigReader
    {
        public static string Base =>
            ConfigurationManager.AppSettings["base"];

        public static string Index =>
            ConfigurationManager.AppSettings["index"];

        public static string Invalid =>
            ConfigurationManager.AppSettings["invalid"];

        public static string AddRemoveElements =>
            ConfigurationManager.AppSettings["add_remove_elements"];

        public static string BasicAuthentication =>
            ConfigurationManager.AppSettings["basic_authentication"];

        public static string BrokenImages =>
            ConfigurationManager.AppSettings["broken_images"];

        public static string Checkboxes =>
            ConfigurationManager.AppSettings["checkboxes"];

        public static string DigestAuthentication =>
            ConfigurationManager.AppSettings["digest_authentication"];

        public static string DragAndDrop =>
            ConfigurationManager.AppSettings["drag_and_drop"];

        public static string Dropdown =>
            ConfigurationManager.AppSettings["dropdown"];

        public static string FormAuthetication =>
            ConfigurationManager.AppSettings["form_authentication"];

        public static string Frames =>
            ConfigurationManager.AppSettings["frames"];

        public static string Hovers =>
            ConfigurationManager.AppSettings["hovers"];

        public static string IFrame =>
            ConfigurationManager.AppSettings["iframe"];

        public static string NestedFrames =>
            ConfigurationManager.AppSettings["nested_frames"];

        public static string JavaScriptAlerts =>
            ConfigurationManager.AppSettings["javascript_alerts"];

        public static string SecureArea =>
            ConfigurationManager.AppSettings["secure_area"];
    }
}
