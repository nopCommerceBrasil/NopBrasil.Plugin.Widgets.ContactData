using NopBrasil.Plugin.Widgets.ContactData.Models;
using System.Text;

namespace NopBrasil.Plugin.Widgets.ContactData.Service
{
    public class ContactDataService : IContactDataService
    {
        private readonly ContactDataSettings _contactDataSettings;

        public ContactDataService(ContactDataSettings contactDataSettings)
        {
            this._contactDataSettings = contactDataSettings;
        }

        private void AddText(StringBuilder sb, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                if (sb.Length > 0)
                {
                    if (_contactDataSettings.ViewMode.Equals("One line"))
                        sb.Append(" - ");
                    else
                        sb.Append("<br/>");
                }
                sb.Append(text);
            }
        }

        private string GetFormattedString()
        {
            StringBuilder sb = new StringBuilder();
            AddText(sb, _contactDataSettings.CompanyName);
            AddText(sb, _contactDataSettings.NationalRegisterCorporate);
            AddText(sb, _contactDataSettings.PhoneNumber);
            AddText(sb, _contactDataSettings.Email);
            AddText(sb, _contactDataSettings.Address);
            AddText(sb, _contactDataSettings.District);
            AddText(sb, _contactDataSettings.PostalCode);
            AddText(sb, _contactDataSettings.City);
            AddText(sb, _contactDataSettings.State);
            return sb.ToString();            
        }

        public PublicInfoModel GetModel() => new PublicInfoModel() { Html = GetFormattedString() };
    }
}
