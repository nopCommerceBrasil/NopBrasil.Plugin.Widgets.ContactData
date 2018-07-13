using NopBrasil.Plugin.Widgets.ContactData.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Controllers;
using NopBrasil.Plugin.Widgets.ContactData.Service;
using Nop.Web.Framework;
using Microsoft.AspNetCore.Mvc;
using Nop.Services.Localization;

namespace NopBrasil.Plugin.Widgets.ContactData.Controllers
{
    [Area(AreaNames.Admin)]
    public class WidgetsContactDataController : BasePluginController
    {
        private readonly ISettingService _settingService;
        private readonly ContactDataSettings _contactDataSettings;
        private readonly IContactDataService _widgetContactDataService;
        private readonly ILocalizationService _localizationService;

        public WidgetsContactDataController(ISettingService settingService, ContactDataSettings contactDataSettings, 
            IContactDataService widgetContactDataService, ILocalizationService localizationService)
        {
            this._settingService = settingService;
            this._contactDataSettings = contactDataSettings;
            this._widgetContactDataService = widgetContactDataService;
            this._localizationService = localizationService;
        }

        public ActionResult Configure()
        {
            var model = new ConfigurationModel()
            {
                WidgetZone = _contactDataSettings.WidgetZone,
                ViewMode = _contactDataSettings.ViewMode,
                CompanyName = _contactDataSettings.CompanyName,
                NationalRegisterCorporate = _contactDataSettings.NationalRegisterCorporate,
                Address = _contactDataSettings.Address,
                PostalCode = _contactDataSettings.PostalCode,
                City = _contactDataSettings.City,
                State = _contactDataSettings.State,
                District = _contactDataSettings.District,
                PhoneNumber = _contactDataSettings.PhoneNumber,
                Email = _contactDataSettings.Email
            };
            return View("~/Plugins/Widgets.ContactData/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public ActionResult Configure(ConfigurationModel model)
        {
            if (!ModelState.IsValid)
            {
                return Configure();
            }
            _contactDataSettings.WidgetZone = model.WidgetZone;
            _contactDataSettings.ViewMode = model.ViewMode;
            _contactDataSettings.CompanyName = model.CompanyName;
            _contactDataSettings.NationalRegisterCorporate = model.NationalRegisterCorporate;
            _contactDataSettings.Address = model.Address;
            _contactDataSettings.PostalCode = model.PostalCode;
            _contactDataSettings.City = model.City;
            _contactDataSettings.State = model.State;
            _contactDataSettings.District = model.District;
            _contactDataSettings.PhoneNumber = model.PhoneNumber;
            _contactDataSettings.Email = model.Email;

            _settingService.SaveSetting(_contactDataSettings);

            SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            return Configure();
        }
    }
}