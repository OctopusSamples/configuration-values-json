using System;
using System.Collections.Generic;
using System.Reflection;
using ConfigurationValues.Settings;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ConfigurationValues.Pages
{
    public class IndexModel : PageModel
    {
        private Dictionary<String, String> _settingValues = new Dictionary<string, string>();

        private readonly ILogger<IndexModel> _logger;
        private readonly IOptions<AppSettings> _settings;

        public IndexModel(ILogger<IndexModel> logger, IOptions<Settings.AppSettings> settings)
        {
            _logger = logger;
            _settings = settings;
        }

        public void OnGet()
        {
            GetSettings(_settings.Value);
            GetSettings(_settings.Value.CustomerSettings);
            GetSettings(_settings.Value.FeatureSettings);
            ViewData["settingValues"] = _settingValues;
        }

        private void GetSettings(object currentObject)
        {
            foreach (PropertyInfo prop in currentObject.GetType().GetProperties())
            {
                if (prop.Name != "CustomerSettings" && prop.Name != "FeatureSettings"){
                    var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                    _settingValues.Add(prop.Name, prop.GetValue(currentObject, null)?.ToString());
                }
            }
        }
    }
}
