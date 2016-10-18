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
                WidgetZone = "home_page_bottom"
            };
            _settingService.SaveSetting(settings);

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.WidgetZone", "WidgetZone name");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.WidgetZone.Hint", "Enter the WidgetZone name that will display the contact data.");

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.ViewMode", "View mode");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.ViewMode.Hint", "Can be: \"bulleted list\" or \"one line\".");

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.CompanyName", "Company name");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.CompanyName.Hint", "Enter the company name.");

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.NationalRegisterCorporate", "National Register Corporate");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.NationalRegisterCorporate.Hint", "Enter the National Register Corporate. In Brazil is used CNPJ.");

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.Address", "Address");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.Address.Hint", "Enter the street and number of company.");

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.PostalCode", "Postal code");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.PostalCode.Hint", "Enter the postal code.");

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.City", "City");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.City.Hint", "Enter the city of company.");

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.State", "State");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.State.Hint", "Enter the state of company.");

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.District", "District");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.District.Hint", "Enter the district of company.");

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.PhoneNumber", "Phone number");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.PhoneNumber.Hint", "Enter the contact phone number.");

            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.Email", "Email");
            this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.Email.Hint", "Enter the contact email.");

            base.Install();
        }

        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<ContactDataSettings>();

            //locales
            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.WidgetZone");
            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.WidgetZone.Hint");

            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.ViewMode");
            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.ViewMode.Hint");

            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.CompanyName");
            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.CompanyName.Hint");

            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.NationalRegisterCorporate");
            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.NationalRegisterCorporate.Hint");

            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.Address");
            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.Address.Hint");

            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.PostalCode");
            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.PostalCode.Hint");

            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.City");
            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.City.Hint");

            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.State");
            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.State.Hint");

            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.District");
            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.District.Hint");

            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.PhoneNumber");
            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.PhoneNumber.Hint");

            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.Email");
            this.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.Email.Hint");

            base.Uninstall();
        }
    }
}
