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
        private readonly ContactDataSettings _ContactDataSettings;
        private readonly IContactDataService _widgetContactDataService;

        public WidgetsContactDataController(ISettingService settingService,
            ContactDataSettings ContactDataSettings, IContactDataService widgetContactDataService)
        {
            this._settingService = settingService;
            this._ContactDataSettings = ContactDataSettings;
            this._widgetContactDataService = widgetContactDataService;
        }

        [AdminAuthorize]
        [ChildActionOnly]
        public ActionResult Configure()
        {
            var model = new ConfigurationModel()
            {
                WidgetZone = _ContactDataSettings.WidgetZone
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
            _ContactDataSettings.WidgetZone = model.WidgetZone;
            _settingService.SaveSetting(_ContactDataSettings);
            return Configure();
        }

        [ChildActionOnly]
        public ActionResult PublicInfo(string widgetZone, object additionalData = null)
        {
             return View("~/Plugins/Widgets.ContactData/Views/WidgetsContactData/PublicInfo.cshtml", _widgetContactDataService.GetModel());
        }
    }
}