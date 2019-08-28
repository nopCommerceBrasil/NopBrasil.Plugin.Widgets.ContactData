using NopBrasil.Plugin.Widgets.ContactData.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Controllers;
using NopBrasil.Plugin.Widgets.ContactData.Service;
using Nop.Web.Framework;
using Microsoft.AspNetCore.Mvc;
using Nop.Services.Localization;
using Nop.Services.Security;
using Nop.Services.Messages;
using Nop.Web.Framework.Mvc.Filters;

namespace NopBrasil.Plugin.Widgets.ContactData.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    public class WidgetsContactDataController : BasePluginController
    {
        private readonly ISettingService _settingService;
        private readonly ContactDataSettings _contactDataSettings;
        private readonly IContactDataService _widgetContactDataService;
        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;

        public WidgetsContactDataController(ISettingService settingService, ContactDataSettings contactDataSettings, 
            IContactDataService widgetContactDataService, ILocalizationService localizationService,
            INotificationService notificationService, IPermissionService permissionService)
        {
            this._settingService = settingService;
            this._contactDataSettings = contactDataSettings;
            this._widgetContactDataService = widgetContactDataService;
            this._localizationService = localizationService;
            this._notificationService = notificationService;
            this._permissionService = permissionService;
        }

        public IActionResult Configure()
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageShippingSettings))
                return AccessDeniedView();

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
        public IActionResult Configure(ConfigurationModel model)
        {
            if (!_permissionService.Authorize(StandardPermissionProvider.ManageShippingSettings))
                return AccessDeniedView();

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

            _notificationService.SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
            return Configure();
        }
    }
}