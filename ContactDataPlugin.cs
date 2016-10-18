using System.Collections.Generic;
using System.Web.Routing;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Media;

namespace NopBrasil.Plugin.Widgets.ContactData
{
    /// <summary>
    /// PLugin
    /// </summary>
    public class ContactDataPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ISettingService _settingService;
        private readonly ContactDataSettings _ContactDataSettings;

        public ContactDataPlugin(IPictureService pictureService,
            ISettingService settingService, ContactDataSettings ContactDataSettings)
        {
            this._settingService = settingService;
            this._ContactDataSettings = ContactDataSettings;
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string> { _ContactDataSettings.WidgetZone };
        }

        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "WidgetsContactData";
            routeValues = new RouteValueDictionary { { "Namespaces", "NopBrasil.Plugin.Widgets.ContactData.Controllers" }, { "area", null } };
        }

        public void GetDisplayWidgetRoute(string widgetZone, out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "PublicInfo";
            controllerName = "WidgetsContactData";
            routeValues = new RouteValueDictionary
            {
                {"Namespaces", "NopBrasil.Plugin.Widgets.ContactData.Controllers"},
                {"area", null},
                {"widgetZone", widgetZone}
            };
        }

        public override void Install()
        {
            var settings = new ContactDataSettings
            {
                WidgetZone = "home_page_before_news"
            };
            _settingService.SaveSetting(settings);

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.WidgetZone", "WidgetZone name");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.WidgetZone.Hint", "Enter the WidgetZone name that will display the contact data.");

            base.Install();
        }

        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<ContactDataSettings>();

            //locales
            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.WidgetZone");
            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.WidgetZone.Hint");

            base.Uninstall();
        }
    }
}
