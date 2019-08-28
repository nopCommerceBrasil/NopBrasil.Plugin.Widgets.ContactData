using System.Collections.Generic;
using Nop.Core;
using Nop.Services.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;

namespace NopBrasil.Plugin.Widgets.ContactData
{
    public class ContactDataPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly ISettingService _settingService;
        private readonly ContactDataSettings _ContactDataSettings;
        private readonly IWebHelper _webHelper;
        private readonly ILocalizationService _localizationService;

        public ContactDataPlugin(ISettingService settingService,
            ContactDataSettings ContactDataSettings, IWebHelper webHelper, ILocalizationService localizationService)
        {
            this._settingService = settingService;
            this._ContactDataSettings = ContactDataSettings;
            this._webHelper = webHelper;
            this._localizationService = localizationService;
        }

        public IList<string> GetWidgetZones() => new List<string> { _ContactDataSettings.WidgetZone };

        public override string GetConfigurationPageUrl() => _webHelper.GetStoreLocation() + "Admin/WidgetsContactData/Configure";

        public override void Install()
        {
            var settings = new ContactDataSettings
            {
                WidgetZone = "footer"
            };
            _settingService.SaveSetting(settings);

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.WidgetZone", "WidgetZone name");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.WidgetZone.Hint", "Enter the WidgetZone name that will display the contact data.");

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.ViewMode", "View mode");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.ViewMode.Hint", "Can be: \"bulleted list\" or \"one line\".");

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.CompanyName", "Company name");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.CompanyName.Hint", "Enter the company name.");

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.NationalRegisterCorporate", "National Register Corporate");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.NationalRegisterCorporate.Hint", "Enter the National Register Corporate. In Brazil is used CNPJ.");

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.Address", "Address");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.Address.Hint", "Enter the street and number of company.");

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.PostalCode", "Postal code");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.PostalCode.Hint", "Enter the postal code.");

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.City", "City");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.City.Hint", "Enter the city of company.");

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.State", "State");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.State.Hint", "Enter the state of company.");

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.District", "District");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.District.Hint", "Enter the district of company.");

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.PhoneNumber", "Phone number");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.PhoneNumber.Hint", "Enter the contact phone number.");

            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.Email", "Email");
            _localizationService.AddOrUpdatePluginLocaleResource("Plugins.Widgets.ContactData.Fields.Email.Hint", "Enter the contact email.");

            base.Install();
        }

        public override void Uninstall()
        {
            //settings
            _settingService.DeleteSetting<ContactDataSettings>();

            //locales
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.WidgetZone");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.WidgetZone.Hint");

            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.ViewMode");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.ViewMode.Hint");

            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.CompanyName");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.CompanyName.Hint");

            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.NationalRegisterCorporate");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.NationalRegisterCorporate.Hint");

            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.Address");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.Address.Hint");

            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.PostalCode");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.PostalCode.Hint");

            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.City");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.City.Hint");

            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.State");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.State.Hint");

            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.District");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.District.Hint");

            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.PhoneNumber");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.PhoneNumber.Hint");

            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.Email");
            _localizationService.DeletePluginLocaleResource("Plugins.Widgets.ContactData.Fields.Email.Hint");

            base.Uninstall();
        }

        public string GetWidgetViewComponentName(string widgetZone) => "WidgetsContactData";

        public bool HideInWidgetList => false;
    }
}
