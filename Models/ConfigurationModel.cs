using Nop.Web.Framework.Mvc.Models;
using System.Collections.Generic;
using Nop.Web.Framework.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public string WidgetZone { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.ViewMode")]
        public string ViewMode { get; set; }

        public IList<SelectListItem> ViewModeAvailable { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.CompanyName")]
        public string CompanyName { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.NationalRegisterCorporate")]
        public string NationalRegisterCorporate { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.Address")]
        public string Address { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.PostalCode")]
        public string PostalCode { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.City")]
        public string City { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.State")]
        public string State { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.District")]
        public string District { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.PhoneNumber")]
        public string PhoneNumber { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.ContactData.Fields.Email")]
        public string Email { get; set; }
    }
}