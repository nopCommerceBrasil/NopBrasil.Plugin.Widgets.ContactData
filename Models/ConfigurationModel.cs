using System.Web.Mvc;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;
using System.Collections.Generic;

namespace NopBrasil.Plugin.Widgets.ContactData.Models
{
    public class ConfigurationModel : BaseNopModel
    {
        public ConfigurationModel()
        {
            ViewModeAvailable = new List<SelectListItem>() { new SelectListItem() { Text = "Bulleted list" }, new SelectListItem() { Text = "One line" } };
        }

        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.WidgetZone")]
        [AllowHtml]
        public string WidgetZone { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.ViewMode")]
        [AllowHtml]
        public string ViewMode { get; set; }

        public IList<SelectListItem> ViewModeAvailable { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.CompanyName")]
        [AllowHtml]
        public string CompanyName { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.NationalRegisterCorporate")]
        [AllowHtml]
        public string NationalRegisterCorporate { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.Address")]
        [AllowHtml]
        public string Address { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.PostalCode")]
        [AllowHtml]
        public string PostalCode { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.City")]
        [AllowHtml]
        public string City { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.State")]
        [AllowHtml]
        public string State { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.District")]
        [AllowHtml]
        public string District { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.PhoneNumber")]
        [AllowHtml]
        public string PhoneNumber { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.Email")]
        [AllowHtml]
        public string Email { get; set; }
    }
}