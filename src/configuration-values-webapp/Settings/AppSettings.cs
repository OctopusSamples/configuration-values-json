namespace ConfigurationValues.Settings
{
    public class AppSettings
    {
        public string AppVersion { get; set; }
        public string EnvironmentName { get; set; }

        public CustomerSettings CustomerSettings { get; set; }

        public FeatureSettings FeatureSettings { get; set; }

        public string DatabaseName
        {
            get
            {
                return $"{EnvironmentName}_CustomerDb_{CustomerSettings.ShortName}";
            }
        }
    }
}