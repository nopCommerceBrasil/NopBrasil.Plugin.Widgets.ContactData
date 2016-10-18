using Nop.Core.Configuration;

namespace NopBrasil.Plugin.Widgets.ContactData
{
    public class ContactDataSettings : ISettings
    {
        public string WidgetZone { get; set; }

        public string ViewMode { get; set; }

        public string CompanyName { get; set; }

        public string NationalRegisterCorporate { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string District { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}