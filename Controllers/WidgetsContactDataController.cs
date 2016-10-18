using System.Web.Mvc;
using NopBrasil.Plugin.Widgets.ContactData.Models;
using Nop.Services.Configuration;
using Nop.Web.Framework.Controllers;
using Nop.Web.Controllers;
using NopBrasil.Plugin.Widgets.ContactData.Service;

namespace NopBrasil.Plugin.Widgets.ContactData.Controllers
{
    public class WidgetsContactDataController : BasePublicController
    {
        private readonly ISettingService _settingService;
        private readonly ContactDataSettings _contactDataSettings;
        private readonly IContactDataService _widgetContactDataService;

        public WidgetsContactDataController(ISettingService settingService,
            ContactDataSettings contactDataSettings, IContactDataService widgetContactDataService)
        {
            this._settingService = settingService;
            this._contactDataSettings = contactDataSettings;
            this._widgetContactDataService = widgetContactDataService;
        }

        [AdminAuthorize]
        [ChildActionOnly]
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
            return View("~/Plugins/Widgets.ContactData/Views/WidgetsContactData/Configure.cshtml", model);
        }

        [HttpPost]
        [AdminAuthorize]
        [ChildActionOnly]
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
            return Configure();
        }

        [ChildActionOnly]
        public ActionResult PublicInfo(string widgetZone, object additionalData = null)
        {
             return View("~/Plugins/Widgets.ContactData/Views/WidgetsContactData/PublicInfo.cshtml", _widgetContactDataService.GetModel());
        }
    }
}