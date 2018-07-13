using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;
using NopBrasil.Plugin.Widgets.ContactData.Service;

namespace NopBrasil.Plugin.Widgets.ContactData.Component
{
    [ViewComponent(Name = "WidgetsContactData")]
    public class WidgetsContactDataViewComponent : NopViewComponent
    {
        private readonly IContactDataService _contactDataService;

        public WidgetsContactDataViewComponent(IContactDataService contactDataService)
        {
            this._contactDataService = contactDataService;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData) => View("~/Plugins/Widgets.ContactData/Views/PublicInfo.cshtml", _contactDataService.GetModel());
    }
}
